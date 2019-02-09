using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody rb;
    private int hit = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed * -1f;
    }

    private void Update()
    {
        if (hit != 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            hit = 1;
        }

        if (collision.gameObject.name == "Border")
        {
            hit = 1;
        }

        if (collision.gameObject.name == "Border2")
        {
            hit = 1;
        }

        if (collision.gameObject.name == "Enemy1")
        {
            hit = 1;
        }
    }
}
