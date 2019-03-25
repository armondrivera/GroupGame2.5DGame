using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatFollow : MonoBehaviour
{
    public Rigidbody2D rb;
    // Update is called once per frame

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("MovePlat"))
        {
            rb.MovePosition(col.rigidbody.position);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("MovePlat"))
        {
            rb.MovePosition(rb.position);
        }
    }
}
