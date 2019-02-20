using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrap : MonoBehaviour
{
    private float trapTimer = 6;
    private float activeTimer = 4;
    private bool trapActive = false;
    private readonly int damage = 1;
    public Animator flameTrapAnim;

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
            flameTrapAnim.SetBool("Active", true);
        }

        if (trapActive == true)
        {
            activeTimer -= Time.deltaTime;
        }

        if (activeTimer <= 0)
        {
            trapActive = false;
            trapTimer = 6;
            activeTimer = 4;
            flameTrapAnim.SetBool("Active", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && trapActive == true)
        {
            other.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
        }
    }
}
