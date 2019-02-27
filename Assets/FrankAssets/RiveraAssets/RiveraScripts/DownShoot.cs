using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Script is Attached to Player Object
public class DownShoot : MonoBehaviour {
	/// <summary>
	/// The maximum number of air jumps the player can perform.
	/// </summary>
	public const int MaxAirJumps = 3; //Implicitly static

	[SerializeField] private Transform firePoint;
	[SerializeField] private GameObject Shot;
	[SerializeField] private float range = 10f;
	[SerializeField] private float damage = 3f;
	[SerializeField] private float shotTimer = 1.5f;
	[SerializeField] private int counter = 0; //Keeps track of if you're able to jump directly off the ground! 1 if you can, 0 if you used it already
	[SerializeField] private int shotCount = 0;

	public event UnityAction onJumpsRemainingChanged;

	public int JumpsRemaining {
		get { return MaxAirJumps - shotCount + counter; }
	}

	private int ShotCount {
		get { return shotCount; }
		set {
			shotCount = value;
			if (onJumpsRemainingChanged != null)
				onJumpsRemainingChanged();
		}
	}

	// Start is called before the first frame update
	void Awake() {

	}

	// Update is called once per frame
	void Update() {
		if (shotCount > 0) {
			shotTimer -= Time.deltaTime;
		}

		if (shotTimer <= 0f) {
			ShotCount--;
			shotTimer = 1.5f;
		}

		if (Input.GetKeyDown(KeyCode.Z) && counter == 0 && shotCount < MaxAirJumps) {
			ShootBullet();
			Shot.transform.position += new Vector3(60, 0, 0);
			ShotCount++;
		}
	}

	void OnCollisionEnter(Collision Floor) {
		if (Floor.gameObject.tag == "Floor") {
			counter = 1;
			if (onJumpsRemainingChanged != null)
				onJumpsRemainingChanged();
		}
	}

	private void OnCollisionExit(Collision collision) {
		if (collision.gameObject.tag == "Floor") {
			counter = 0;
			if (onJumpsRemainingChanged != null)
				onJumpsRemainingChanged();
		}
	}

	void ShootBullet() {
		Instantiate(Shot, firePoint.position, firePoint.rotation);

	}
}
