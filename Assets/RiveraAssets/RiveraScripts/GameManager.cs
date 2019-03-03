using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Note: slightly advanced topic: This is a singleton
//The GameManager will maintain (ONLY ONE) static instance of itself (the GameManager class)
//That way, you can easily access everything in your game statically (that deserves to be accessed as such)
public class GameManager : MonoBehaviour {
	private static GameManager instance;

	//This is going to have to be changed if you want multiple scenes. Just take note hehe :) yw.
	//FOR NOW: This will reference the already-instantiated player GameObject (roughly speaking) in the scene -- AND it must be in the same scene!
	//(Cross-scene referencing NOT supported)
	[SerializeField] private HealthScript playerHealth;
	private DownShoot playerMovement;


	public static HealthScript PlayerHealth {
		get { return (instance == null) ? null : instance.playerHealth; }
	}

	public static DownShoot PlayerDownShoot {
		get { return (instance == null) ? null : instance.playerMovement; }
	}

	public void Awake() {
		if (instance != null && instance != this) {
			GameObject.DestroyImmediate(gameObject);
			return;
		}
		instance = this;

		playerMovement = playerHealth.GetComponent<DownShoot>();
	}


}
