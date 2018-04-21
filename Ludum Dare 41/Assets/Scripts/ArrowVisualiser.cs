using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowVisualiser : MonoBehaviour
{
    public ArrowGenerator arrowGenerator;

    public GameObject arrowUp;
    public GameObject arrowDown;
    public GameObject arrowLeft;
    public GameObject arrowRight;

    GameObject[] arrows;

    void Start ()
	{
	    arrows = new GameObject[] { arrowUp, arrowDown, arrowLeft, arrowRight };
    }
	
	void Update ()
	{
		
	}

    public void displayArrow(int index)
    {

        GameObject selectedArrow = arrows[index];
    }
}
