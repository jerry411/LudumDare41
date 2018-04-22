using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowState : MonoBehaviour
{
    public GameObject hitArea;

    public AccelerationCorrectArrows stats;

    public bool active;

    public bool isInHitArea;

    public bool isHit;

    public Sprite ArrowUpGood;
    public Sprite ArrowDownGood;
    public Sprite ArrowLeftGood;
    public Sprite ArrowRightGood;

    public Sprite ArrowUpBad;
    public Sprite ArrowDownBad;
    public Sprite ArrowLeftBad;
    public Sprite ArrowRightBad;

    void Start ()
	{
        active = true;
	    hitArea = GameObject.Find("HitArea");
	    stats = GameObject.Find("GameManager").GetComponent<AccelerationCorrectArrows>();
	}
	
	void Update ()
	{
	    float translation = Screen.width / 2f / 2f * Time.deltaTime;
	    transform.Translate(new Vector3(-translation, 0f, 0f));

	    if (transform.position.x < - 50)
	    {
	        Destroy(gameObject);
	    }
    }

    public void GotAfterHitArea()
    {
        if (!isHit)
        {
            //stats.AddMalus();
            //stats.BreakStreak();
            ChangeColorWrongHit();
        }

        //hitArea.GetComponent<HitArea>().arrowsInHitArea.Dequeue();
        //hitArea.GetComponent<HitArea>().arrowsInHitArea.Remove(gameObject);
    }

    public void Hit(bool goodHit)
    {
        Debug.Log(string.Format("HIT  {0}", goodHit));

        isHit = true;
        active = false;
        hitArea.GetComponent<HitArea>().arrowsInHitArea.Dequeue();

        if (goodHit)
        {
            //stats.AddToStreak();
            //stats.BreakMalus();
            ChangeColorGoodHit();
        }
        else
        {
            //stats.AddToStreak();
            //stats.BreakStreak();
            ChangeColorWrongHit();
        }
    }

    void ChangeColorWrongHit()
    {
        switch (name)
        {
            case "ArrowUp(Clone)":
                GetComponent<Image>().sprite = ArrowUpBad;
                break;
            case "ArrowDown(Clone)":
                GetComponent<Image>().sprite = ArrowDownBad;
                break;
            case "ArrowLeft(Clone)":
                GetComponent<Image>().sprite = ArrowLeftBad;
                break;
            case "ArrowRight(Clone)":
                GetComponent<Image>().sprite = ArrowRightBad;
                break;
        }
    }

    void ChangeColorGoodHit()
    {
        switch (name)
        {
            case "ArrowUp(Clone)":
                GetComponent<Image>().sprite = ArrowUpGood;
                break;
            case "ArrowDown(Clone)":
                GetComponent<Image>().sprite = ArrowDownGood;
                break;
            case "ArrowLeft(Clone)":
                GetComponent<Image>().sprite = ArrowLeftGood;
                break;
            case "ArrowRight(Clone)":
                GetComponent<Image>().sprite = ArrowRightGood;
                break;
        }
    }

}
