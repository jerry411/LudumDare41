using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyChange : MonoBehaviour
{
    public Slider slider;

	void Start ()
	{
	    PlayerPrefs.SetFloat("Difficulty", slider.value);
	}
	

	public void ChangeDifficulty (float newValue)
	{
	    PlayerPrefs.SetFloat("Difficulty", slider.value);
    }
}
