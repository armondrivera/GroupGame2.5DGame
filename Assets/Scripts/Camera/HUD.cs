using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	[SerializeField] private SegmentedBar hpBar;
	[SerializeField] private SegmentedBar jumpBar;

	//Start, so that it happens AFTER the GameManager's Awake() does its initialization
	public void Start() {
		GameManager.PlayerHealth.onHPChanged += OnPlayerHPChanged;
		OnPlayerHPChanged();

		GameManager.PlayerDownShoot.onJumpsRemainingChanged += OnJumpsRemainingChanged;
		OnJumpsRemainingChanged();
	}

	private void OnPlayerHPChanged() {
		//Setting the MaxHP is a little much, but it checks first that the value *actually* changed before
		//performing the relatively expensive array resizing, instantiating GameObjects, and all.
		hpBar.MaxValue = GameManager.PlayerHealth.MaxHP;
		hpBar.Value = GameManager.PlayerHealth.HP;
	}

	private void OnJumpsRemainingChanged() {
		jumpBar.Value = GameManager.PlayerDownShoot.JumpsRemaining;
	}
}
