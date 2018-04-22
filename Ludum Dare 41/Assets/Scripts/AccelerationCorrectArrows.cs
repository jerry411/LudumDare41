﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccelerationCorrectArrows : MonoBehaviour
{
    public int streakCount = 0;
    public int malusStreakCounter = 0;
    public Slider streakVal;
    public Slider malusVal;
    bool gotRight;
    public Karts kart;
    public GameObject kartGO;

    bool aceleing;
    bool deceilng;
	void Update ()
    {
        streakVal.value = streakCount / 10;
        malusVal.value = malusStreakCounter / 3;

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            BreakMalus();
            AddToStreak();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            BreakStreak();
            AddMalus();
        }

        if (streakCount >= 10)
        {
            streakCount = 10;
            StartCoroutine(Accelerate());
            streakCount = 0;
        }

        if (malusStreakCounter >= 3)
        {
            malusStreakCounter = 3;
            StartCoroutine(Decellerate());
            malusStreakCounter = 0;
        }

	}

    public void AddToStreak()
    {
        streakCount += 1;
    }

    public void BreakStreak()
    {
        streakCount = 0;

    }

    public void AddMalus()
    {
        malusStreakCounter += 1;
    }

    public void BreakMalus()
    {
        malusStreakCounter = 0;

    }

    IEnumerator Accelerate()
    {

        kart.StreakBoost(kartGO);
        Debug.Log("Boosted!");
        yield return new WaitForSeconds(10f);
        
        kart.StreakSlowDown(kartGO);

    }

    IEnumerator Decellerate()
    {
     
        kart.MalusSlow(kartGO);
        Debug.Log("Slowed!!");
        deceilng = true;
        yield return new WaitForSeconds(10f);
        

        kart.MalusFastAgain(kartGO);
        deceilng = false;
    }

}
