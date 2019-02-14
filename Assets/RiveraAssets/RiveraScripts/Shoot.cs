using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Shot;
    public float range = 10f;
    public float damage = 3f;

    
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            ShootBullet();
            Shot.transform.position += new Vector3(60, 0, 0);
        }


    }
    
    void ShootBullet()
    {
        Instantiate(Shot, firePoint.position, firePoint.rotation);
        
    }
}
