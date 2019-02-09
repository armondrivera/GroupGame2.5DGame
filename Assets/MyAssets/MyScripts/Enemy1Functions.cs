using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1Functions : MonoBehaviour
{
    public Transform eFirePoint;
    public GameObject eShot;
    public float timer = 3.0f;
    public int HP = 3;

    //weird glitch right now where the enemy loses health each time they fire.

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            ShootBullet();
            timer = 3.0f;
        }

        //Destroys the gameObject this script is attached to
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    //spawns a bullet on the position given
    void ShootBullet()
    {
        Instantiate(eShot, eFirePoint.position, eFirePoint.rotation);

    }

    private void OnTriggerEnter(Collider collision)
    {
            HP--;
    }
}
