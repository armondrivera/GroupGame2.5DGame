using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElecTrap : MonoBehaviour
{

    private float trapTimer = 4;
    private float activeTimer = 2;
    private bool trapActive = false;
    private readonly int damage = 1;
    public Animator elecTrapAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (trapTimer > 0)
        {
            trapTimer -= Time.deltaTime;
        }

        if (trapTimer <= 0)
        {
            trapActive = true;
            elecTrapAnim.SetBool("Active", true);
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
            elecTrapAnim.SetBool("Active", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && trapActive == true)
        {
            other.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
        }
    }
}
