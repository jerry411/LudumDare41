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

    public Canvas spawnArea;
    public Canvas GUI;

    GameObject[] arrows;   

    List<GameObject> activeArrows;
    List<GameObject> allArrows;

    void Start ()
	{
	    arrows = new GameObject[] { arrowUp, arrowDown, arrowLeft, arrowRight };
	    activeArrows = new List<GameObject>();
	    allArrows = new List<GameObject>();
	}
	
	void Update ()
	{

	}

    public void spawnArrow(int index)
    {
        GameObject selectedArrow = arrows[index];

        Vector3 spawnPosition = spawnArea.transform.position;

        switch (index)
        {
            case 0: spawnPosition.y -= 25; break;
            case 1: spawnPosition.y -= 75; break;
            case 2: spawnPosition.y -= 125; break;
            case 3: spawnPosition.y -= 175; break;
        }

        GameObject newArrow = Instantiate(selectedArrow, spawnPosition, Quaternion.identity);

        newArrow.transform.SetParent(GUI.transform, true);

        //newArrow.GetComponent<ArrowState>();
        activeArrows.Add(newArrow);
        allArrows.Add(newArrow);
    }
}
