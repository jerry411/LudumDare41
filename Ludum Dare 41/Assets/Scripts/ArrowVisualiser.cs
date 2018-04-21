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

    List<GameObject> activeArrows;

    void Start ()
	{
	    arrows = new GameObject[] { arrowUp, arrowDown, arrowLeft, arrowRight };
    }
	
	void Update ()
	{
	    foreach (GameObject arrow in activeArrows)
	    {
	        MoveArrow(arrow);
	    }
	}

    void MoveArrow(GameObject arrow)
    {
        throw new System.NotImplementedException();
    }

    public void displayArrow(int index)
    {

        GameObject selectedArrow = arrows[index];
    }
}
