using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMoveFloor : MonoBehaviour
{
    public float setSpeed;
    public float downLimit;
    public float upLimit;
    private float minRange;
    private float maxRange;
    private float dirX, moveSpeed;
    public bool moveRight = true;

    private void Start()
    {
        moveSpeed = setSpeed;
        minRange = transform.position.y - downLimit;
        maxRange = transform.position.y + upLimit;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y > maxRange)
        {
            moveRight = false;
        }

        if (transform.position.y < minRange)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }
    }
}
