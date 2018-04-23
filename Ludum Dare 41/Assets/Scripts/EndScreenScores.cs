using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScores : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    private void Start()
    {
             
        if (PlayerPrefs.GetFloat("DistanceTravelled", 0f) > PlayerPrefs.GetFloat("HighScore", 0f))
        {
            PlayerPrefs.SetFloat("HighScore", PlayerPrefs.GetFloat("DistanceTravelled"));
        }

        scoreText.text = String.Format("{0:0.00}", PlayerPrefs.GetFloat("DistanceTravelled", 0f) / 1000f);
        highScoreText.text = String.Format("{0:0.00}", PlayerPrefs.GetFloat("HighScore", 0f) / 1000f);

        PlayerPrefs.Save();
    }

    public void ResetHighScore()
    {
        highScoreText.text = String.Format("{0:0.00}", 0f);
        PlayerPrefs.SetFloat("HighScore", 0f);
    }
}
