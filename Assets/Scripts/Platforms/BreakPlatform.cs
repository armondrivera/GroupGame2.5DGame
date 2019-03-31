using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlatform : MonoBehaviour
{
    public float crumbleTimer = 3f;
    private float rebuildTimer = 9f;
    public bool theTouch = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (theTouch == true)
        {
            crumbleTimer -= Time.deltaTime;
        }

        if (crumbleTimer < 0)
        {
            Destroy(gameObject);
            rebuildTimer -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            theTouch = true;
        }
    }
}
