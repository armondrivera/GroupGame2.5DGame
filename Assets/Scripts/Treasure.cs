﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private ScoreHolder scoreHolderRef;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            scoreHolderRef = GameObject.FindWithTag("SceneController").GetComponent<ScoreHolder>();
            scoreHolderRef.IncreaseScore();
            Destroy(gameObject);
        }
    }
}