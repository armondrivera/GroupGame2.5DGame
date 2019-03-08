using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Note: slightly advanced topic: This is a singleton
//The GameManager will maintain (ONLY ONE) static instance of itself (the GameManager class)
//That way, you can easily access everything in your game statically (that deserves to be accessed as such)
public class GameManager : MonoBehaviour {
	private static GameManager instance;
    public GameObject gameOverCanvas;

	//This is going to have to be changed if you want multiple scenes. Just take note hehe :) yw.
	//FOR NOW: This will reference the already-instantiated player GameObject (roughly speaking) in the scene -- AND it must be in the same scene!
	//(Cross-scene referencing NOT supported)
	[SerializeField] private HealthScript playerHealth;

	[Header("Helpful Developer Tools")]
	[Tooltip("Enabling this allows you to put in helpful shortcuts into the game, for developers and demonstration purposes only." +
		"\nThis can also be useful for when presenting your game, and you need to get to the end of a difficult level, for example." +
		"\n\nAccess this in scripts statically by using GameManager.IsDeveloperMode.")]
	[SerializeField] private bool isDeveloperMode = true;

	private DownShoot playerMovement;


	public static HealthScript PlayerHealth {
		get { return (instance == null) ? null : instance.playerHealth; }
	}

	public static DownShoot PlayerDownShoot {
		get { return (instance == null) ? null : instance.playerMovement; }
	}

	/// <summary>
	/// <para>Enabling this allows you to put in helpful shortcuts into the game, for developers and demonstration purposes only.</para>
	/// <para>This can also be useful for when presenting your game, and you need to get to the end of a difficult level, for example.</para>
	/// </summary>
	public static bool IsDeveloperMode {
		get { return instance != null && instance.isDeveloperMode; }
	}

	public void Awake() {
		if (instance != null && instance != this) {
			GameObject.DestroyImmediate(gameObject);
			return;
		}
		instance = this;

		if (playerHealth != null) {
			playerMovement = playerHealth.GetComponent<DownShoot>();
			playerHealth.onDeath += OnPlayerDeath;
            gameOverCanvas.SetActive(true);
        }
	}



	private void OnPlayerDeath() {
		Debug.Log("The player has died! Ouch." +
			"\nYou can use the onDeath C# event from anywhere! For example: \"GameManager.PlayerHealth.onDeath += TheNameOfYourMethod;\"");
        gameOverCanvas.SetActive(true);
	}
}
