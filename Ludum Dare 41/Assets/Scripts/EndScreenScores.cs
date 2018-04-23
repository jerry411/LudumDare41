using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScores : MonoBehaviour
{
    public DistanceCalculator distCalc;
    public Text scoreText;
    public Text highScoreText;

    private void Start()
    {
        distCalc = GameObject.FindGameObjectWithTag("DistanceCalculator").GetComponent<DistanceCalculator>();
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    // Update is called once per frame
    void Update ()
    {
        scoreText.text = distCalc.simpleDist.ToString();

        if(distCalc.simpleDist > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", distCalc.simpleDist);
            highScoreText.text = distCalc.simpleDist.ToString();
        }
	}
}
