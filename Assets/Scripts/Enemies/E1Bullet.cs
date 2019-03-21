using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E1Bullet : MonoBehaviour
{
	public float speed = 20f;
	public Rigidbody2D rb;
	public int damage = 1;
	private bool isColliding = false;

	// Start is called before the first frame update
	public void Start() {
		rb.velocity = -transform.up * speed;
	}

	public void Update() {
		isColliding = false;
        
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player" && isColliding == false) {
			isColliding = true;
			other.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
			Destroy(gameObject);
		}
        else
        {
            Destroy(gameObject);
        }
	}
}
