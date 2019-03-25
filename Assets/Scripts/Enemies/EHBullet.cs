using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EHBullet : MonoBehaviour
{
    public float speed = 0.1f;
    public int damage = 1;
    private bool isColliding = false;

    // Start is called before the first frame update
    public void Start()
    {
        transform.position += transform.right * speed;
    }

    public void Update()
    {
        isColliding = false;
        transform.position += transform.right * speed;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && isColliding == false)
        {
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
