using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    private int currentScore = 0;
    private int highScore;

    void Start() {
        scoreText.text = "Score: " + currentScore.ToString("0");
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    public void ScoreUpdate()
    {   
        scoreText.text = "Score: " + currentScore.ToString("0");

        if(currentScore > highScore){
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    public int getScore() {
        return currentScore;
    }

    public void AddScore(int score)
    {
        currentScore += score;
        ScoreUpdate();
    }
}
