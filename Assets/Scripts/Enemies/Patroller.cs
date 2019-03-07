using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    public float setSpeed;
    public GameObject bullet;
    public float leftLimit;
    public float rightLimit;
    private float minRange;
    private float maxRange;
    private float dirX, moveSpeed;
    public float LeftOrRight;
    public bool moveRight = true;
    public Transform moveF;
    public Transform eyes;
    public Transform eyes2;
    public float sight;
    public float fireRate;
    private float fireRateSpare;

    private void Start()
    {
        fireRateSpare = fireRate;
        moveSpeed = setSpeed;
        minRange = transform.position.x - leftLimit;
        maxRange = transform.position.x + rightLimit;
    }

    // Update is called once per frame
    void Update()
    {
        //ray cast sight
        RaycastHit hit;

        Ray losRayR = new Ray(eyes.position, Vector3.right);
        Ray losRayL = new Ray(eyes.position, Vector3.left);

        if (Physics.Raycast(losRayR, out hit, sight))
        {
            fireRate -= Time.deltaTime;
            if (hit.collider.tag == "Player" && fireRate < 0)
            {
                Instantiate(bullet, eyes.position, eyes.rotation);
                fireRate = fireRateSpare;
            }
        }

        if (Physics.Raycast(losRayL, out hit, sight))
        {
            fireRate -= Time.deltaTime;
            if (hit.collider.tag == "Player" && fireRate < 0)
            {
                Instantiate(bullet, eyes2.position, eyes2.rotation);
                fireRate = fireRateSpare;
            }
        }

        //Movement
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
            LeftOrRight = 1f;
            transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            LeftOrRight = -1f;
            transform.position = new Vector3(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
