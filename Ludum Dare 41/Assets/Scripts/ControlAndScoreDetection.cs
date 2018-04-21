using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControlAndScoreDetection : MonoBehaviour
{
    public ArrowVisualiser visualiser;

    public AccelerationCorrectArrows stats;

    public Canvas hitArea;

	void Start ()
	{
		
	}	

	void Update ()
	{
	    if (!Input.anyKey)
	    {
            return;
	    }

	    GameObject leftMostArrow = GetLeftMostActiveArrow();

	    if (leftMostArrow == null)
	    {
            return;
	    }

	    if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
	    {
            return;
	    }

        switch (leftMostArrow.name)
	    {
	        case "ArrowUp":
	            if (Input.GetAxis("Vertical") > 0)
	            {
	                leftMostArrow.GetComponent<ArrowState>().Hit(true);
	            }
	            else
	            {
	                leftMostArrow.GetComponent<ArrowState>().Hit(false);
                }
	            break;
	        case "ArrowDown":
	            if (Input.GetAxis("Vertical") < 0)
	            {
	                leftMostArrow.GetComponent<ArrowState>().Hit(true);
	            }
	            else
	            {
	                leftMostArrow.GetComponent<ArrowState>().Hit(false);
	            }
                break;
	        case "ArrowLeft":
	            if (Input.GetAxis("Horizontal") < 0)
	            {
	                leftMostArrow.GetComponent<ArrowState>().Hit(true);
	            }
	            else
	            {
	                leftMostArrow.GetComponent<ArrowState>().Hit(false);
	            }
                break;
	        case "ArrowRight":
	            if (Input.GetAxis("Horizontal") > 0)
	            {
	                leftMostArrow.GetComponent<ArrowState>().Hit(true);
	            }
	            else
	            {
	                leftMostArrow.GetComponent<ArrowState>().Hit(false);
	            }
                break;
	    }
	}

    private GameObject GetLeftMostActiveArrow()
    {
        return hitArea.GetComponent<HitArea>().arrowsInHitArea.OrderBy(x => x.transform.position.x).FirstOrDefault();
    }
}
