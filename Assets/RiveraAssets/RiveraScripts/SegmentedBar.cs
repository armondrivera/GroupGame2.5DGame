using UnityEngine;
using UnityEngine.UI;

public class SegmentedBar : MonoBehaviour {
	private BarPiece[] barPieces;
	private int value;
	
	public int MaxValue {
		get { return barPieces.Length; }
	}

	public int Value {
		get { return value; }
		set {
			this.value = Mathf.Clamp(value, 0, MaxValue);
			UpdateAllBarPieces();
		}
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
}