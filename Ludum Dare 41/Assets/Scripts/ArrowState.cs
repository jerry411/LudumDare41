using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowState : MonoBehaviour
{
    Canvas hitArea;

    AccelerationCorrectArrows stats;

    public bool active;

    public bool isInHitArea;

    public bool isHit;

	void Start ()
	{
        active = true;
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
            stats.AddMalus();
            stats.BreakStreak();
        }

        hitArea.GetComponent<HitArea>().arrowsInHitArea.Remove(gameObject);
    }

    void Hit()
    {
        isHit = true;

        stats.AddToStreak();
        stats.BreakMalus();

        //TODO: change color/fade
    }
}
