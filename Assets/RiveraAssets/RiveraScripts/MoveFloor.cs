using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    public float move = 3f;
    public float switchTimer = 0f;
    public bool switchNow = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (switchNow == true)
        {
            transform.Translate(Vector3.right * Time.deltaTime * Mathf.PingPong(move, 3));
        }

        if (switchTimer > 0)
        {
            switchTimer -= Time.deltaTime;
        }

        //switch movement
        if (switchTimer <= 0 && switchNow == true)
        {
            switchNow = false;
            switchTimer = 4f;
        }
        else
        {
            if (switchNow == false)
            {
                switchNow = true;
                switchTimer = 4f;
            }
        }

        if (switchNow == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * Mathf.PingPong(move, 3));
        }
    }
}
