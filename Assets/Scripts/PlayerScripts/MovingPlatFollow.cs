using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatFollow : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("MovePlat"))
        {
            gameObject.transform.SetParent(col.transform);
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag.Equals("MovePlat"))
        {
            gameObject.transform.SetParent(null);
        }
    }
}
