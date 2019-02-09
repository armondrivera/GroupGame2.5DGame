using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    //The code for health subtracting may need to be a separate script
    //Check this link for a solution
    //https://answers.unity.com/questions/369380/lose-health-on-collision.html

    public Rigidbody playerRb;
    public Transform playerT;
    public float moveSpeed = 1.0f;
    public float upForce = 5f;
    public float bullUpForce = 5f;
    public float shotTimer = 3.0f;
    public float rotatePos = 0.0f;
    public int jumpShotCount = 0;
    public int plat = 0;
    public int HP = 5;
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
            shotTimer = 3.0f;
        }

        //Jumps
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MoveUp();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {

        }

        //Move Left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        //MoveRight
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }

        //Rotate
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (rotatePos != 180)
            {
                FlipLeft();
            }
        }

        //Rotate
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (rotatePos != 0)
            {
                FlipRight();
            }
            
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            plat = 1;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
         HP--;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
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
        //playerRb.velocity.y = playerRb.velocity.y * 0.5f;
    }

    void MoveLeft()
    {
        transform.position += new Vector3(-1, 0, 0) * moveSpeed;
        
    }

    void MoveRight()
    {
        transform.position += new Vector3(1, 0, 0) * moveSpeed;
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
