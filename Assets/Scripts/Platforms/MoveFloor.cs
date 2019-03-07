using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    public float setSpeed;
    public float leftLimit;
    public float rightLimit;
    private float minRange;
    private float maxRange;
    private float dirX, moveSpeed;
    public bool moveRight = true;

    private void Start()
    {
        moveSpeed = setSpeed;
        minRange = transform.position.x - leftLimit;
        maxRange = transform.position.x + rightLimit;
    }

    // Update is called once per frame
    void Update()
    {

       if (transform.position.x > maxRange)
        {
            moveRight = false;
        }

        if (transform.position.x < minRange)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }
}
