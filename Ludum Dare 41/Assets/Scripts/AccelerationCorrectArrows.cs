using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccelerationCorrectArrows : MonoBehaviour
{
    public int streakCount = 0;
    public int malusStreakCounter = 0;

    bool gotRight;
    public Karts kart;
    public GameObject kartGO;

    public Animator animator;

    public GameObject boost;
    public GameObject malus;
    //bool aceleing;
    //bool deceilng;

    void Update ()
    {

        /*if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            BreakMalus();
            AddToStreak();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            BreakStreak();
            AddMalus();
        }*/

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
        animator.SetBool("isBoosted", true);
        Debug.Log("Boosted!");
        StartCoroutine(displayUi());
        yield return new WaitForSeconds(10f);
        
        kart.StreakSlowDown(kartGO);
        animator.SetBool("isBoosted", false);

    }

    IEnumerator Decellerate()
    {
     
        kart.MalusSlow(kartGO);
        Debug.Log("Slowed!!");
        StartCoroutine(displayUi1());
        yield return new WaitForSeconds(10f);
        

        kart.MalusFastAgain(kartGO);
    }

    IEnumerator displayUi()
    {
        boost.SetActive(true);
        yield return new WaitForSeconds(2f);
        boost.SetActive(false);
    }

    IEnumerator displayUi1()
    {
        malus.SetActive(true);
        yield return new WaitForSeconds(2f);
        malus.SetActive(false);
    }
}
