using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Script is Attached to Player Object
public class DownShoot : MonoBehaviour {
	[SerializeField] private Transform firePoint;
	[SerializeField] private GameObject bulletPrefab;

	[Space(20)]
	[SerializeField] private int maxAirJumps = 3;
	[SerializeField] private float range = 10;
	[SerializeField] private float damage = 3;
	[SerializeField] private float shotTimer = 1.5f;

	//You can always see private instance fields (like these, counter, and shotCount) in the "debug mode Inspector".
	//To turn on the debug mode Inspector, go to the triple horizontal bars
	//at the top right of your Inspector window, and click on "Debug" to turn it on, "Normal" to go back to the normal Inspector you're used to.
	private int groundJumpsRemaining = 0;
	private int airJumpsUsed = 0;

	public event UnityAction onJumpsRemainingChanged;

	public int MaxAirJumps {
		get { return maxAirJumps; }
	}

	public int JumpsRemaining {
		get { return maxAirJumps - airJumpsUsed + groundJumpsRemaining; }
	}

	public int GroundJumpsRemaining {
		get { return groundJumpsRemaining; }
		private set { //private is IMPORTANT here!
			groundJumpsRemaining = value;
			if (onJumpsRemainingChanged != null)
				onJumpsRemainingChanged();
		}
	}

	public int AirJumpsUsed {
		get { return airJumpsUsed; }
		private set { //private is IMPORTANT here!
			airJumpsUsed = value;
			if (onJumpsRemainingChanged != null)
				onJumpsRemainingChanged();
		}
	}

	public void Update() {
		if (airJumpsUsed > 0) {
			shotTimer -= Time.deltaTime;
		}

		if (shotTimer <= 0f) {
			AirJumpsUsed--;
			shotTimer = 1.5f;
		}

		if (Input.GetKeyDown(KeyCode.Z) && groundJumpsRemaining == 0 && airJumpsUsed < maxAirJumps) {
			//ShootBullet();
			//bulletPrefab.transform.position += new Vector3(60, 0, 0);
			AirJumpsUsed++;
		}
	}

	void OnCollisionEnter(Collision Floor) {
		if (Floor.gameObject.tag == "Floor") {
			GroundJumpsRemaining = 1;
		}
	}

	private void OnCollisionExit(Collision collision) {
		if (collision.gameObject.tag == "Floor") {
			GroundJumpsRemaining = 0;
		}
	}

	private void ShootBullet() {
		//GameObject.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
	}
}
