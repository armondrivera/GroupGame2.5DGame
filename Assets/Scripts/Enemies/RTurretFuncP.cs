using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RTurretFuncP : MonoBehaviour
{
    public Transform eFirePoint;
    public Transform target;
    public GameObject eShot;
    public float LeftOrRight;
    public float speed = 0.11f;
    private float timer = 0f;
    private float rotatePos;
    public bool inSight = false;
    public Animator turretAnim;

    public float sight;

    private void Start()
    {
        rotatePos = transform.eulerAngles.y;
        turretAnim = GetComponent<Animator>();
    }

    //Contains Timer, chase, and line of sight code
    //https://answers.unity.com/questions/989092/do-you-know-any-patrolling-ai-script-for-a-navmesh.html
    void Update()
    {
        //Debug.DrawRay(eFirePoint.position, Vector3.right * LeftOrRight * sight, Color.red);
        //Shoot Timer
        if (timer > 0 && inSight == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && inSight == true)
        {
            ShootBullet();
            timer = 0f;
        }

        //ray cast sight
        RaycastHit2D hit = Physics2D.Raycast(eFirePoint.position, Vector2.left * LeftOrRight * sight);
        
            if (hit.collider)
            {
                if (hit.collider.tag == "Player")
                {
                    turretAnim.SetBool("Seen", true);
                    Spotted(true);
                }
            }
            else
            {
                turretAnim.SetBool("Seen", false);
                Spotted(false);
            }
    }

    private void FlipRight()
    {
        gameObject.transform.Rotate(Vector2.up * 180);
        rotatePos = 0f;
    }

    private void FlipLeft()
    {
        gameObject.transform.Rotate(Vector2.up * 180);
        rotatePos = 180f;
    }

    //spawns a bullet on the position given
    void ShootBullet()
    {
        Instantiate(eShot, eFirePoint.position, eFirePoint.rotation);

    }


    private void OnTriggerEnter2D(Collider2D collision)
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
