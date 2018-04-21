using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ControlAndScoreDetection : MonoBehaviour
{
    ArrowVisualiser visualiser;

    AccelerationCorrectArrows stats;

    Canvas hitArea;

	void Start ()
	{
		
	}	

	void Update ()
	{
	    GameObject leftMostArrow = GetLeftMostActiveArrow();

	    if (leftMostArrow == null)
	    {
            return;
	    }

	    if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
	    {
                return;
	    }

	    if (leftMostArrow.name == "ArrowUp")
	    {
	        
	    }

	    if (leftMostArrow.name == "ArrowDown")
	    {

	    }

	    if (leftMostArrow.name == "ArrowLeft")
	    {

	    }

	    if (leftMostArrow.name == "ArrowRight")
	    {

	    }

    }

    private GameObject GetLeftMostActiveArrow()
    {
        return hitArea.GetComponent<HitArea>().arrowsInHitArea.OrderBy(x => x.transform.position.x).FirstOrDefault();       
    }
}
