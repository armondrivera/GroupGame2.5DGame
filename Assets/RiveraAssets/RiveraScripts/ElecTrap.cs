using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecTrap : MonoBehaviour
{

    private float trapTimer = 4;
    private float activeTimer = 2;
    private bool trapActive = false;
    public GameObject player;
    private int damage = 2;

    public float sight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray trapRay = new Ray(transform.position, Vector3.down);

        if (trapTimer > 0)
        {
            trapTimer -= Time.deltaTime;
        }

        if (trapTimer <= 0)
        {
            trapActive = true;
        }

        if (trapActive == true)
        {
            activeTimer -= Time.deltaTime;
        }

        if (activeTimer <= 0)
        {
            trapActive = false;
            trapTimer = 4;
            activeTimer = 2;
        }

        if (trapActive == true && Physics.Raycast(trapRay, out hit, sight))
        {
            if (hit.collider.tag == "Player")
            {
                player.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
            }
        }
        
    }
}
