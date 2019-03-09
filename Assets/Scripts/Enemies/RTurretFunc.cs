using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RTurretFunc : MonoBehaviour
{
    public Transform eFirePoint;
    public Transform target;
    public GameObject eShot;
    public float LeftOrRight;
    public float speed = 0.11f;
    private float timer = 1f;
    private float rotatePos;
    public bool inSight = false;
    public int damage = 1;
    public GameObject player;


    public float sight;

    private void Start()
    {
        rotatePos = transform.eulerAngles.y;
    }

    //Contains Timer, chase, and line of sight code
    //https://answers.unity.com/questions/989092/do-you-know-any-patrolling-ai-script-for-a-navmesh.html
    void Update()
    {
        //Shoot Timer
        if (timer > 0 && inSight == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && inSight == true)
        {
            ShootBullet();
            timer = 1f;
        }

        //ray cast sight
        RaycastHit hit;

        Ray losRayR = new Ray(transform.position, Vector3.right * LeftOrRight);

        if (Physics.Raycast(losRayR, out hit, sight))
        {
            if (hit.collider.tag == "Player")
            {
                player.GetComponent<HealthScript>().TakeDamage(damage);
            }
            else
            {
                Spotted(false);
            }
        }
        else
        {
            Spotted(false);
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


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Death();
        }
    }

    void Spotted(bool seen)
    {
        inSight = seen;
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
