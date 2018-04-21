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
	    activeArrows = new List<GameObject>();
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
        float translation = Screen.width / 2f / 120f * Time.deltaTime;
        arrow.transform.Translate(new Vector3(-10, 0, 0));
    }

    public void spawnArrow(int index)
    {
        GameObject selectedArrow = arrows[index];

        Vector3 spawnPosition = spawnArea.transform.position;

        switch (index)
        {
            case 0: spawnPosition.y -= 50; break;
            case 1: spawnPosition.y -= 110; break;
            case 2: spawnPosition.y -= 170; break;
            case 3: spawnPosition.y -= 230; break;
        }

        Instantiate(selectedArrow, spawnPosition, Quaternion.identity);

        activeArrows.Add(selectedArrow);
    }
}
