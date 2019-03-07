using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootablePlatform : MonoBehaviour
{
    public GameObject leftSide;
    public GameObject rightSide;
    public bool shotL = false;
    public bool shotR = false;
    public float moveTime = 3f;
    private float spareTime;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        spareTime = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (shotL == true)
        {
            moveTime -= Time.deltaTime;
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }

        if (shotR == true)
        {
            moveTime -= Time.deltaTime;
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }

        if (moveTime < 0 && shotL == true)
        {
            shotL = false;
            moveTime = spareTime;
        }

        if (moveTime < 0 && shotR == true)
        {
            shotR = false;
            moveTime = spareTime;
        }

        if (leftSide.GetComponent<ShootablePlatformSide>().shot == true && rightSide.GetComponent<ShootablePlatformSide>().shot == false)
        {
            shotL = true;
            shotR = false;
        }
        else
        {
            if (rightSide.GetComponent<ShootablePlatformSide>().shot == true && leftSide.GetComponent<ShootablePlatformSide>().shot == false)
            {
                shotR = true;
                shotL = false;
            }
        }
    }
}
