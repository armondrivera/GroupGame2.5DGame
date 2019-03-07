using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHolder : MonoBehaviour
{
    private int currentScore = 0;
    //Need to make the canvas
    public Text scoreText;
    public GameObject gameOverCanvas;
    public HealthScript check;
    //public GameObject winImage;
    //public int winScore;
    // Start is called before the first frame update
    void Start()
    {
        //winImage.SetActive(false);
        UpdateUI();
        gameOverCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (GetComponent<HealthScript>().hp <= 0)
        {
            //gameOverCanvas.SetActive(true);
        }*/
    }

    void UpdateUI()
    {
        scoreText.text = "Treasure Collected: " + currentScore.ToString();

        if (check.HP <= 0)
        {
            gameOverCanvas.SetActive(true);
        }
    }

    public void IncreaseScore()
    {
        currentScore++;
        UpdateUI();
    }

}
