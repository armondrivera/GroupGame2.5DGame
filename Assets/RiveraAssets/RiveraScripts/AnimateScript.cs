using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateScript : MonoBehaviour
{
    Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerAnim.SetBool("Run", true);
        }

        if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            playerAnim.SetBool("Run", false);
        }
    }
}
