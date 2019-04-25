using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;
    bool slide = false;

    float dashTimer = 0.14f;


    public AudioScript noise;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        //Slide right into the dm's
        if (Input.GetButtonDown("Fire1"))
        {
            slide = true;
            noise.PlaySlideSound();
        }

    }

    void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove * runSpeed * Time.fixedDeltaTime, false, jump, slide);
        jump = false;

        if (slide)
        {
            dashTimer -= Time.deltaTime;
        }

        if (dashTimer <= 0f)
        {
            dashTimer = 0.14f;
            slide = false;
        }
    }
}
