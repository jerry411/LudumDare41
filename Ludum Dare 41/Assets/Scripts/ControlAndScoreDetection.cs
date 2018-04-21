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
            //return;
	    }

	    //Debug.Log(hitArea.GetComponent<HitArea>().arrowsInHitArea.Count);

        GameObject leftMostArrow = GetLeftMostActiveArrow();

	    if (leftMostArrow == null)
	    {
            return;
	    }

	    //Debug.Log(hitArea.GetComponent<HitArea>().arrowsInHitArea.Peek().name);

        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
	    {
            return;
	    }

        switch (leftMostArrow.name)
	    {
	        case "ArrowUp(Clone)":
	            if (Input.GetAxis("Vertical") > 0)
	            {
	                leftMostArrow.GetComponent<ArrowState>().Hit(true);
	            }
	            else
	            {
	                leftMostArrow.GetComponent<ArrowState>().Hit(false);
                    Debug.Log("UP");
                }
	            break;
	        case "ArrowDown(Clone)":
	            if (Input.GetAxis("Vertical") < 0)
	            {
	                leftMostArrow.GetComponent<ArrowState>().Hit(true);
	            }
	            else
	            {
	                leftMostArrow.GetComponent<ArrowState>().Hit(false);
	                Debug.Log("DOWN");
                }
                break;
	        case "ArrowLeft(Clone)":
	            if (Input.GetAxis("Horizontal") < 0)
	            {
	                leftMostArrow.GetComponent<ArrowState>().Hit(true);
	            }
	            else
	            {
	                leftMostArrow.GetComponent<ArrowState>().Hit(false);
	                Debug.Log("LEFT");
                }
                break;
	        case "ArrowRight(Clone)":
	            if (Input.GetAxis("Horizontal") > 0)
	            {
	                leftMostArrow.GetComponent<ArrowState>().Hit(true);
	            }
	            else
	            {
	                leftMostArrow.GetComponent<ArrowState>().Hit(false);
	                Debug.Log("RIGHT");
                }
                break;
	    }
	}

    private GameObject GetLeftMostActiveArrow()
    {
        if (hitArea.GetComponent<HitArea>().arrowsInHitArea.Count == 0)
        {
            return null;
        }

        return hitArea.GetComponent<HitArea>().arrowsInHitArea.Peek();
        //return hitArea.GetComponent<HitArea>().arrowsInHitArea.OrderBy(x => x.transform.position.x).FirstOrDefault();
    }
}
