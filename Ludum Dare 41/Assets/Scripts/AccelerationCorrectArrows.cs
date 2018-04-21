using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationCorrectArrows : MonoBehaviour {

    private int streakCount = 0;
    private int malusStreakCounter = 0;

    bool gotRight;

	// Update is called once per frame
	void Update ()
    {


        if (gotRight)
            AddToStreak();
        
	}

    void AddToStreak()
    {
        streakCount += 1;
    }

    void BreakStreak()
    {
        streakCount = 0;
        AddMalus();
    }

    void AddMalus()
    {
        malusStreakCounter += 1;
    }

    void BreakMalus()
    {
        malusStreakCounter = 0;
        AddToStreak();
    }


}
