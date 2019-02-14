using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script is Attached to Player Object
public class DownShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Shot;
    public float range = 10f;
    public float damage = 3f;
    public float shotTimer = 1.5f;
    public int counter = 0;
    public int shotCount = 0;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shotCount > 0)
        {
            shotTimer -= Time.deltaTime;
        }

        if (shotTimer <= 0f)
        {
            shotCount--;
            shotTimer = 1.5f;
        }

        if (Input.GetKeyDown(KeyCode.Z) && counter == 0 && shotCount < 3)
        {
            ShootBullet();
            Shot.transform.position += new Vector3(60, 0, 0);
            shotCount++;
        }
    }

    void OnCollisionEnter(Collision Floor)
    {
        if (Floor.gameObject.tag == "Floor")
        {
            counter = 1;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            counter = 0;
        }
    }

    void ShootBullet()
    {
        Instantiate(Shot, firePoint.position, firePoint.rotation);

    }
}
