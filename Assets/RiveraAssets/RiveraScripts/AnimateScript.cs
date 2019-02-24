using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateScript : MonoBehaviour
{
    Animator playerAnim;
    private float dashTimer = 0.8f;
    private float jumpTwo = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && playerAnim.GetBool("Grounded") == true && playerAnim.GetBool("Dash") == false && dashTimer != 0.8 ||  Input.GetKey(KeyCode.RightArrow)
            && playerAnim.GetBool("Grounded") == true && playerAnim.GetBool("Dash") == false)
        {
            playerAnim.SetBool("Run", true);
        }
        else
        {
            playerAnim.SetBool("Run", false);
        }

        /*if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) 
            && playerAnim.GetBool("Grounded") == true && playerAnim.GetBool("Dash") == false)
        {
            playerAnim.SetBool("Run", false);
        }*/

        if (Input.GetKeyDown(KeyCode.C))
        {
            playerAnim.SetBool("Run", false);
            playerAnim.SetBool("Dash", true);
            playerAnim.SetBool("Run", false);
        }

        if (playerAnim.GetBool("Dash") == true)
        {
            dashTimer -= Time.fixedDeltaTime;
        }

        if (dashTimer <= 0)
        {
            playerAnim.SetBool("Dash", false);
            dashTimer = 0.8f;
            playerAnim.SetBool("Jump", false);
            playerAnim.SetBool("2ndJump", false);
        }

        if (gameObject.GetComponent<Movement2>().plat == 0)
        {
            playerAnim.SetBool("Jump", true);
            playerAnim.SetBool("Grounded", false);
        }

        if (Input.GetKeyDown(KeyCode.Z) && playerAnim.GetBool("Jump") == true)
        {
            playerAnim.SetBool("2ndJump", true);
            jumpTwo -= Time.fixedDeltaTime;
            playerAnim.SetBool("Grounded", false);
        }

        if (jumpTwo <= 0)
        {
            playerAnim.SetBool("2ndJump", false);
            jumpTwo = 0.8f;
        }

        if (gameObject.GetComponent<Movement2>().plat == 1)
        {
            playerAnim.SetBool("Jump", false);
            playerAnim.SetBool("HitGround", true);
            playerAnim.SetBool("Grounded", true);
            playerAnim.SetBool("2ndJump", false);
            jumpTwo = 0.8f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            playerAnim.SetBool("Grounded", true);
            jumpTwo = 0.8f;
        }
    }
}
