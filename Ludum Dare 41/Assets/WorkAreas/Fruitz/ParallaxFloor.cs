﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxFloor : MonoBehaviour {

    public Camera cam;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
		
	}
}
