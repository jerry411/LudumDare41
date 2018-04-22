using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StreakCounterUI : MonoBehaviour
{
    public AccelerationCorrectArrows streakScript;

    public Sprite[] streakCounters;
    public Image streakSprite;

    // Update is called once per frame
    void Update ()
    {
        streakSprite.sprite = streakCounters[streakScript.streakCount];
	}
}
