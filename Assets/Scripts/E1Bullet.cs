using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1Bullet : MonoBehaviour {
	public float speed = 20f;
	public Rigidbody rb;
	private int damage = 1;
	private bool isColliding = false;

	// Start is called before the first frame update
	public void Start() {
		rb.velocity = transform.right * speed;
	}

	public void Update() {
		isColliding = false;

		if (transform.position.x <= -68) {
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "Player" && isColliding == false) {
			isColliding = true;
			other.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}
