using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxFloor : MonoBehaviour {

    public int leftIndex;
    public int rightIndex;
    public Transform[] roads;

    public float bgSize;
    public float viewZone = 10f;
    public Camera cam;

    private void Start()
    {
        roads = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            roads[i] = transform.GetChild(i);
        }

        cam = Camera.main;
        leftIndex = 0;
        rightIndex = roads.Length - 1;
    }

    public void ScrollLeft()
    {
        int lastRight = rightIndex;
        roads[rightIndex].position = new Vector3(roads[leftIndex].position.x - bgSize, roads[leftIndex].position.y, roads[leftIndex].position.z);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = roads.Length - 1;
    }

    public void ScrollRight()
    {
        int lastLeft = leftIndex;
        roads[leftIndex].position = new Vector3(roads[rightIndex].position.x + bgSize, roads[leftIndex].position.y, roads[leftIndex].position.z)  ;

        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == roads.Length)
            leftIndex = 0;
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //    ScrollLeft();
        //if (Input.GetMouseButtonDown(1))
        //    ScrollRight();

        if (cam.transform.position.x < (roads[leftIndex].position.x + viewZone))
            ScrollLeft();

        if (cam.transform.position.x > (roads[rightIndex].position.x - viewZone))
            ScrollRight();

    }

}
