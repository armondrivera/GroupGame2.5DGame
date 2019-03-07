using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatFollow : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("MovePlat"))
        {
            this.transform.parent = col.transform;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag.Equals("MovePlat"))
        {
            this.transform.parent = null;
        }
    }
}
