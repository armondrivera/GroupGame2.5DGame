using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public Rigidbody playerRb;
    public Transform playerT;
    public float moveSpeed = 0.14f;
    public float dashSpeed = 10.0f;

    private bool isDashing = false;

    public float upForce = 5f;
    public float bullUpForce = 5f;

    public float shotTimer = 1.5f;
    public float dashTimer = 0.5f;

    public float rotatePos = 0.0f;

    public int jumpShotCount = 0;

    public int plat = 0;
    //private float temp = 0.14f;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpShotCount > 0)
        {
            shotTimer -= Time.deltaTime;
        }

        if (shotTimer <= 0f)
        {
            jumpShotCount--;
            shotTimer = 1.5f;
        }

        //Jumps
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MoveUp();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            isDashing = true;
        }

        if (isDashing == true)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer > 0f)
            {
                Dash();
            }

            if (dashTimer <= 0f)
            {
                dashTimer = 0.5f;
                transform.position += Vector3.zero;
                playerRb.velocity = Vector3.zero;
                isDashing = false;
            }
        }

        //Move Left
        if (Input.GetKey(KeyCode.LeftArrow) && isDashing == false)
        {
            MoveLeft();
        }
        
        //MoveRight
        if (Input.GetKey(KeyCode.RightArrow) && isDashing == false)
        {
            MoveRight();
        }

        //Rotate
        if (Input.GetKeyDown(KeyCode.LeftArrow) && isDashing == false)
        {
            if (rotatePos != 180)
            {
                FlipLeft();
            }
        }

        

        //Rotate
        if (Input.GetKeyDown(KeyCode.RightArrow) && isDashing == false)
        {
            if (rotatePos != 0)
            {
                FlipRight();
            }
            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            plat = 1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            plat = 0;
        }
    }

    //Code for jumping and double jumps
    void MoveUp()
    {
        if (plat == 0 && jumpShotCount < 3)
        {
            playerRb.AddForce(Vector3.up * bullUpForce);
            jumpShotCount++;
        }
        else
            if(plat == 1)
        {
            playerRb.AddForce(Vector3.up * upForce);
        }
    }

    void MoveDown()
    {
        Physics.gravity = new Vector3(0, -1.0F, 0);
    }

    void MoveLeft()
    {
        transform.position += new Vector3(-1, 0, 0) * moveSpeed;
        
    }

    void MoveRight()
    {
        transform.position += new Vector3(1, 0, 0) * moveSpeed;
    }

    void Dash()
    {
        if (rotatePos == 0)
        {
            gameObject.transform.position += new Vector3(1, 0, 0) * 0.7f;
            //playerRb.AddForce(Vector3.right * dashSpeed);
        }

        if (rotatePos == 180)
        {
            gameObject.transform.position += new Vector3(-1, 0, 0) * 0.7f;
            //playerRb.AddForce(-Vector3.right * dashSpeed);
        }

    }

    void FlipLeft()
    {
        playerT.Rotate(Vector3.up * 180);
        rotatePos = 180f;
    }

    void FlipRight()
    {
        playerT.Rotate(Vector3.up * 180);
        rotatePos = 0f;
    }
}
