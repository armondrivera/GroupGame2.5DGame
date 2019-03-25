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
            GetComponent<Rigidbody2D>().isKinematic = true;
            transform.parent = col.transform;
            GetComponent<Movement2>().plat = 1;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("MovePlat"))
        {
            GetComponent<Rigidbody2D>().isKinematic = false;

            transform.parent = null;
        }
    }
}
