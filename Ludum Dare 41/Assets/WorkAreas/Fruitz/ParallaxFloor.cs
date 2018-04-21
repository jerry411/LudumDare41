using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxFloor : MonoBehaviour {

    public Camera cam;
    public Transform[] roads;
    private float viewZone

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
		cam.vi
	}
}
