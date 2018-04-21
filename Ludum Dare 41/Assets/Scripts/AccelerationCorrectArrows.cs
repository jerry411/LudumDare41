using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationCorrectArrows : MonoBehaviour
{
    private int streakCount = 0;
    private int malusStreakCounter = 0;

    bool gotRight;


	void Update ()
    {

        
	}

    public void AddToStreak()
    {
        streakCount += 1;
    }

    public void BreakStreak()
    {
        streakCount = 0;
        AddMalus();
    }

    public void AddMalus()
    {
        malusStreakCounter += 1;
    }

    public void BreakMalus()
    {
        malusStreakCounter = 0;
        AddToStreak();
    }
}
