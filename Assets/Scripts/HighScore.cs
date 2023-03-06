using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class HighScore : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    private int highScore;

    void Start()
    {
        highScoreText.text = "HS : " + PlayerPrefs.GetInt("HighScore").ToString();
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    void FixedUpdate()
    {
        int tempHS = PlayerPrefs.GetInt("HighScore");
        if(tempHS > highScore){
            PlayerPrefs.SetInt("HighScore", tempHS);
        }
    }
}
