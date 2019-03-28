using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public Rigidbody2D playerRb;
    public Transform playerT;
    public float moveSpeed = 0.14f;
    private float spareMoveSpeed;
    public float dashSpeed = 10.0f;

    private bool isDashing = false;
    private bool isShooting = false;
    private bool stay;

    private float curY;
    private float groundY;

    public float upForce = 5f;
    public float bullUpForce = 5f;

    public float shotRefillTimer = 1.5f;
    public float dashTimer = 0.14f;


    private float shootTimer = 0.2f;
    private float spareShoot;

    public float rotatePos = 0f;

    public int jumpShotCount = 0;

    public Animator playerA;

    public int plat = 0;
    //private float temp = 0.14f;

    private void Awake()
    {
        spareMoveSpeed = moveSpeed;
        spareShoot = shotRefillTimer;
        playerRb = GetComponent<Rigidbody2D>();
        playerA = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //updating variables
        curY = gameObject.transform.position.y;

        if (jumpShotCount > 0)
        {
            shotRefillTimer -= Time.deltaTime;
        }

        if (shotRefillTimer <= 0f)
        {
            jumpShotCount--;
            shotRefillTimer = spareShoot;
        }

        //Jumps
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MoveUp();
        }

        //Slide right into the dm's
        if (Input.GetKeyDown(KeyCode.C))
        {
            isDashing = true;
        }

        if (isDashing == true && plat == 1)
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer > 0f)
            {
                Dash();
            }
        }
        else
        {
            isDashing = false;
            dashTimer = 0.14f;
        }

        if (dashTimer <= 0f)
        {
            dashTimer = 0.14f;
			playerRb.position += Vector2.zero;
            playerRb.velocity = Vector2.zero;
            isDashing = false;
        }

        //Move Left
        if (Input.GetKey(KeyCode.LeftArrow) && isDashing == false)
        {
            //playerA.SetBool("move", true);
            //playerA.SetBool("grounded", true);
            MoveLeft();
        }

        //MoveRight
        if (Input.GetKey(KeyCode.RightArrow) && isDashing == false)
        {
            //playerA.SetBool("move", true);
            //playerA.SetBool("grounded", true);
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
        else
        {
            //playerA.Play("Ikera-Idle");
        }

        if (curY == groundY || stay == true)
        {
            plat = 1;
        }
        else
        {
            plat = 0;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "MovePlat")
        {
            groundY = curY;
            jumpShotCount = 0;
            stay = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "MovePlat")
        {
            plat = 0;
            stay = false;
        }
    }

    //Code for jumping and double jumps
    void MoveUp()
    {
        if (plat == 0 && jumpShotCount < 3)
        {
            playerRb.AddForce(Vector2.up * bullUpForce);
            jumpShotCount++;
        }
        else
            if (plat == 1)
            {
                playerRb.AddForce(Vector2.up * upForce);
            }
    }

    void MoveDown()
    {
        Physics.gravity = new Vector2(0, -1);
    }

    void MoveLeft()
    {
		playerRb.position += new Vector2(-1, 0) * moveSpeed;

    }

    void MoveRight()
    {
		playerRb.position += new Vector2(1, 0) * moveSpeed;
    }

    void Dash()
    {
        if (rotatePos == 0)
        {
			playerRb.position += new Vector2(1, 0) * 0.62f;
            //playerRb.AddForce(Vector3.right * dashSpeed);
        }

        if (rotatePos == 180)
        {
			playerRb.position += new Vector2(-1, 0) * 0.62f;
            //playerRb.AddForce(-Vector3.right * dashSpeed);
        }

    }

    void FlipLeft()
    {
        playerT.Rotate(Vector2.up * 180);
        rotatePos = 180;
    }

    void FlipRight()
    {
        playerT.Rotate(Vector2.up * 180);
        rotatePos = 0f;
    }

    /*
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

    void OnCollisionStay(Collision collision)
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
    }*/
}
