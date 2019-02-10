using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1Functions : MonoBehaviour
{
    public Transform eFirePoint;
    public Transform target;
    public GameObject eShot;
    public float speed = 1f;
    public float timer = 3.0f;
    public float rotatePos = 0;
    public bool inSight = false;

    // Contains Timer, chase, and line of sight code
    void Update()
    {
        if (timer > 0 && inSight == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && inSight == true)
        {
            ShootBullet();
            timer = 3.0f;
        }

        //Line of Sight code
        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.right * -1);

        if (angle < 60.0f)
        {
            Spotted(true);
        }

        //movement code
        if (target.position.x < gameObject.transform.position.x)
        {
            gameObject.transform.position += new Vector3(speed, 0, 0) * -1;
            if (rotatePos != 180)
            {
                FlipLeft();
            }
        }

        if (target.position.x > gameObject.transform.position.x)
        {
            gameObject.transform.position += new Vector3(speed, 0, 0);
            if (rotatePos != 0)
            {
                FlipRight();
            }
        }
    }

    private void FlipRight()
    {
        gameObject.transform.Rotate(Vector3.up * 180);
        rotatePos = 0f;
    }

    private void FlipLeft()
    {
        gameObject.transform.Rotate(Vector3.up * 180);
        rotatePos = 180f;
    }

    //spawns a bullet on the position given
    void ShootBullet()
    {
        Instantiate(eShot, eFirePoint.position, eFirePoint.rotation);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Death();
        }
    }

    public void Spotted(bool seen)
    {
        inSight = seen;
    }

    private void Death()
    {
        Destroy(gameObject);
    }
}
