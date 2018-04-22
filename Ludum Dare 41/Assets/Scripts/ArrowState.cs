using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowState : MonoBehaviour
{
    public GameObject hitArea;

    public AccelerationCorrectArrows stats;

    public bool active;

    public bool isInHitArea;

    public bool isHit;

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

    void GotAfterHitArea()
    {
        if (!isHit)
        {
            //stats.AddMalus();
            //stats.BreakStreak();
        }

        hitArea.GetComponent<HitArea>().arrowsInHitArea.Dequeue();
        //hitArea.GetComponent<HitArea>().arrowsInHitArea.Remove(gameObject);
    }

    public void Hit(bool goodHit)
    {
        //Debug.Log("HIT");

        isHit = true;
        active = false;
        hitArea.GetComponent<HitArea>().arrowsInHitArea.Dequeue();

        if (goodHit)
        {
            //stats.AddToStreak();
            //stats.BreakMalus();
        }
        else
        {
            //stats.AddToStreak();
            //stats.BreakStreak();
        }
        

        //TODO: change color/fade
    }
}
