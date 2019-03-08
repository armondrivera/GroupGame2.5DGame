using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootablePlatformSide : MonoBehaviour
{

    public bool shot = false;
    private float wait = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shot == true)
        {
            wait -= Time.deltaTime;
        }

        if (wait < 0)
        {
            shot = false;
            wait = 2f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            shot = true;
        }
    }
}
