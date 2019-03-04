using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//SegmentedBars should (currently) rely on a HorizontalLayoutGroup or VerticalLayoutGroup to
//automatically position the bar pieces. This makes life easier on us :) thanks Unity! <3
[RequireComponent(typeof(LayoutGroup))]
public class SegmentedBar : MonoBehaviour {

	[SerializeField] private BarPiece barPiecePrefab;
	[Space(20)]
	[SerializeField] private int lowestSupportedMaxValue = 1;
	[SerializeField] private int highestSupportedMaxValue = 8;

	private BarPiece[] barPieces;
	private int value;
	
	//More C# properties, just as done in HealthScript.cs :)
	public int LowestSupportedMaxValue {
		get { return lowestSupportedMaxValue; }
	}

	public int HighestSupportedMaxValue {
		get { return highestSupportedMaxValue; }
	}

	public int MaxValue {
		get { return barPieces.Length; }
		set {
			int newLength = Mathf.Clamp(value, lowestSupportedMaxValue, highestSupportedMaxValue);
			if (newLength != value) {
				Debug.LogError("Attempted to set an invalid MaxValue for the " + typeof(SegmentedBar).Name + " at the following path:" +
					"\n" + UnityUtil.GetAbsolutePath(transform) + "!" +
					"\nIt was attempted to be set to " + value + ", which is outside the supported range of [" + lowestSupportedMaxValue + ", " + highestSupportedMaxValue + "].");
			}
			if (newLength == MaxValue)
				return;
			BarPiece[] newArray = new BarPiece[newLength];
			int minLength = Mathf.Min(barPieces.Length, newLength);

			//Copy over all the "old data" from the 1st array
			for (int i = 0; i < minLength; i++)
				newArray[i] = barPieces[i];
			//This happens if there are now not enough BarPieces instantiated!
			for (int i = barPieces.Length; i < newLength; i++)
				newArray[i] = GameObject.Instantiate(barPiecePrefab.gameObject, transform).GetComponent<BarPiece>();
			//This happens if there are now too many BarPieces instantiated!
			for (int i = newLength; i < barPieces.Length; i++)
				GameObject.Destroy(barPieces[i].gameObject);

			//Old barPieces array is able to be garbage collected,
			//since nothing references it, and the reference has been changed to the newArray!
			barPieces = newArray;
			UpdateLayoutGroup();
		}
	}

	public int Value {
		get { return value; }
		set {
			this.value = Mathf.Clamp(value, 0, MaxValue);
			UpdateAllBarPieces();
		}
	}

	public void OnValidate() {
		lowestSupportedMaxValue = Mathf.Max(1, lowestSupportedMaxValue);
		highestSupportedMaxValue = Mathf.Max(lowestSupportedMaxValue, highestSupportedMaxValue);
	}

	public void Awake() {
		barPieces = GetComponentsInChildren<BarPiece>();
	}

	/// <summary>
	/// Visually update all the BarPieces to show or not show each of them individually
	/// </summary>
	private void UpdateAllBarPieces() {
		for (int i = 0; i < value; i++)
			barPieces[i].SetState(true);
		for (int i = value; i < barPieces.Length; i++)
			barPieces[i].SetState(false);
	}

	private void UpdateLayoutGroup() {
		StartCoroutine(ForceLayoutGroupUpdate());
	}

	private IEnumerator ForceLayoutGroupUpdate() {
		RectTransform r = transform as RectTransform;
		Vector2 original = r.sizeDelta;
		r.sizeDelta = original + new Vector2(0.05f, 0.05f);

		yield return null; //Waits 1 frame.
		r.sizeDelta = original;
	}
}