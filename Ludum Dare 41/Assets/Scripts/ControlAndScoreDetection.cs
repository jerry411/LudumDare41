using System;
using UnityEngine;

public class ControlAndScoreDetection : MonoBehaviour
{
    public ArrowVisualiser visualiser;

    public AccelerationCorrectArrows stats;

    public Canvas hitArea;

    private float lastTimeHorizontal;
    private float lastTimeVertical;

	void Update ()
	{
	    //Debug.Log(hitArea.GetComponent<HitArea>().arrowsInHitArea.Count);

        float currentHorizontal = Input.GetAxis("Horizontal");
	    float currentVertical = Input.GetAxis("Vertical");

        if (CheckAgainstPreviousInput(currentHorizontal, currentVertical))
            return;

	    lastTimeHorizontal = currentHorizontal;
	    lastTimeVertical = currentVertical;        

        GameObject leftMostArrow = GetLeftMostActiveArrow();

	    if (leftMostArrow == null)
	    {
            return;
	    }

	    //Debug.Log(String.Format("{0}    {1}", Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")));       

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
                    //Debug.Log("UP");
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
	                //Debug.Log("DOWN");
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
	                //Debug.Log("LEFT");
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
	                //Debug.Log("RIGHT");
                }
                break;
	    }
	}

    private bool CheckAgainstPreviousInput(float currentHorizontal, float currentVertical)
    {
        if (!Input.anyKey)
        {
            lastTimeHorizontal = 0;
            lastTimeVertical   = 0;
            return true;
        }

        if ((currentHorizontal != 0 && currentVertical != 0) || (currentHorizontal == 0 && currentVertical == 0))
        {
            lastTimeHorizontal = 0;
            lastTimeVertical   = 0;
            return true;
        }

        if ((lastTimeHorizontal > 0 && currentHorizontal > 0) || (lastTimeHorizontal < 0 && currentHorizontal < 0))
        {
            return true;
        }

        if ((lastTimeVertical > 0 && currentVertical > 0) || (lastTimeVertical < 0 && currentVertical < 0))
        {
            return true;
        }

        return false;
    }

    private GameObject GetLeftMostActiveArrow()
    {
        if (hitArea.GetComponent<HitArea>().arrowsInHitArea.Count == 0)
        {
            return null;
        }

        return hitArea.GetComponent<HitArea>().arrowsInHitArea.Peek();
    }
}
