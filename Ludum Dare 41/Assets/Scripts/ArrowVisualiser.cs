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

    public void spawnArrow(int index)
    {
        GameObject selectedArrow = arrows[index];

        Vector3 spawnPosition = spawnArea.transform.position;

        switch (index)
        {
            case 0: spawnPosition.y += 20; break;
            case 1: spawnPosition.y += 40; break;
            case 2: spawnPosition.y += 60; break;
            case 3: spawnPosition.y += 80; break;
        }

        Instantiate(selectedArrow, spawnPosition, Quaternion.identity);

        activeArrows.Add(selectedArrow);
    }
}
