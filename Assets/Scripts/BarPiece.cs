using UnityEngine;
using UnityEngine.UI;

public class BarPiece : MonoBehaviour {
	[Tooltip("The piece that is activated to show this bar piece is on.")]
	[SerializeField] private Image onPiece;

	/// <summary>
	/// Turns this BarPiece on or off. (Insert better description here)
	/// </summary>
	public void SetState(bool value) {
		onPiece.gameObject.SetActive(value);
	}
}
