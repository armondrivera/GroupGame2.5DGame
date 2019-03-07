using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlatformManage : MonoBehaviour
{
    public float rebuildTimer = 9.0f;
    public bool theTouch = false;
    private float crumbleTimer = 3f;
    public GameObject platform;
    public GameObject spare;

    // Start is called before the first frame update
    void Start()
    {
        spare = platform;
        Instantiate(platform, gameObject.transform.position, gameObject.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (theTouch == true)
        {
            crumbleTimer -= Time.deltaTime;
        }

        if (crumbleTimer < 0 && theTouch == true)
        {
            rebuildTimer -= Time.deltaTime;
        }

        if (rebuildTimer < 0)
        {
            platform = spare;
            Instantiate(platform, gameObject.transform.position, gameObject.transform.rotation);
            crumbleTimer = 3f;
            theTouch = false;
            rebuildTimer = 9f;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && rebuildTimer == 9.0f)
        {
            theTouch = true;
        }
    }

}
