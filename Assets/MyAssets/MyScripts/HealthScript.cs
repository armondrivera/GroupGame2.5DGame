using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public float maxHP = 10;
    private float curHP;
    public bool alive = true;
    // Start is called before the first frame update
    void Start()
    {
        curHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        if (!alive)
        {
            return;
        }

        if (curHP <= 0)
        {
            curHP = 0;
            alive = false;
            Destroy(gameObject);
        }

        curHP -= amount;
        print(curHP);
    }
}
