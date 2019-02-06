using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up * speed * -1f;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
