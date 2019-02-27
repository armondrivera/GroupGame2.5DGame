using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateScript : MonoBehaviour
{
    [Tooltip("The minimum speed in which the player must be moving in m/s, such that if they stopped or reverse direction, they will have to turn.")]
    [Range(0, 30)]
    [SerializeField] private float turnSpeedThreshold = 10;

    private Animator animator;
    private float dashTimer = 0.8f;
    private float jumpTwo = 0.8f;

    //Velocity is a vector -- means it has multiple components or "dimensions" -- made of SEVERAL numbers.
    private Vector3 prevVelocity;
    private float prevSignedSpeed;
    private Vector3 prevPosition;
    private Vector3 position;
    //Note that speed is a scalar AND is NEVER negative.

    public void Awake()
    {
        animator = GetComponent<Animator>();

        prevPosition = transform.position;
        position = prevPosition;
    }

    public void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && animator.GetBool("GroundedId") && !animator.GetBool("DashId") && dashTimer != 0.8 || Input.GetKey(KeyCode.RightArrow)
            && animator.GetBool("GroundedId") && !animator.GetBool("DashId"))
        {
            animator.SetBool("RunId", true);
        }
        else
        {
            animator.SetBool("RunId", false);
        }

        /*if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) 
            && playerAnim.GetBool(GroundedId) == true && playerAnim.GetBool(DashId) == false)
        {
            playerAnim.SetBool(RunId, false);
        }*/

        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("RunId", false);
            animator.SetBool("DashId", true);
            animator.SetBool("RunId", false);
        }

        if (animator.GetBool("DashId") == true)
        {
            dashTimer -= Time.fixedDeltaTime;
        }

        if (dashTimer <= 0)
        {
            animator.SetBool("DashId", false);
            dashTimer = 0.8f;
            animator.SetBool("JumpId", false);
            animator.SetBool("SecondJumpId", false);
        }

        if (gameObject.GetComponent<Movement2>().plat == 0)
        {
            animator.SetBool("JumpId", true);
            animator.SetBool("GroundedId", false);
        }

        if (Input.GetKeyDown(KeyCode.Z) && animator.GetBool("JumpId") == true)
        {
            animator.SetBool("SecondJumpId", true);
            jumpTwo -= Time.fixedDeltaTime;
            animator.SetBool("GroundedId", false);
        }

        if (jumpTwo <= 0)
        {
            animator.SetBool("SecondJumpId", false);
            jumpTwo = 0.8f;
        }

        if (gameObject.GetComponent<Movement2>().plat == 1)
        {
            animator.SetBool("JumpId", false);
            animator.SetBool("HitGroundId", true);
            animator.SetBool("GroundedId", true);
            animator.SetBool("SecondJumpId", false);
            jumpTwo = 0.8f;
        }

        TurnUpdate();
    }

    private void TurnUpdate()
    {
        position = transform.position;

        //Whenever you have deltas, you always use "final - initial". Ex: Δx = (x_f - x_i)
        Vector3 velocity = (position - prevPosition) / Time.fixedDeltaTime; //v = Δx / Δt		or	v = dx/dt
        float signedSpeed = velocity.magnitude;

        if (Mathf.Abs(prevSignedSpeed) >= turnSpeedThreshold)
        {
            //Positive previous signed speed
            if (prevSignedSpeed > 0)
            {
                if (signedSpeed <= 0)
                    animator.SetTrigger("TurnId");
            }
            else
            { //Negative previous signed speed
                if (signedSpeed >= 0)
                    animator.SetTrigger("TurnId");
            }
        }

        prevVelocity = velocity;
        prevSignedSpeed = signedSpeed;
        prevPosition = position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            animator.SetBool("GroundedId", true);
            jumpTwo = 0.8f;
        }
    }
    /*Animator playerAnim;
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

        if ((Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) 
            && playerAnim.GetBool("Grounded") == true && playerAnim.GetBool("Dash") == false)
        {
            playerAnim.SetBool("Run", false);
        }

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
    }*/
}
