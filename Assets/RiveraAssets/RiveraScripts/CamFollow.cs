using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    public GameObject player;

    public float followSpeed;

    //distance between ship and camera
    private float camToPlayerDistance;


    private void Start()
    {
        transform.position = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        camToPlayerDistance = Vector2.Distance(transform.position, player.transform.position);

        //goes from one position to another position by a certain amount
        transform.position = Vector2.Lerp(transform.position, player.transform.position, camToPlayerDistance * followSpeed * Time.deltaTime);

    }
}
