using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartMovement : MonoBehaviour {

    Karts kart;

	void Start ()
    {
        kart = new Karts(gameObject);
	}
	
	void FixedUpdate () {
        kart.MoveAhead();
    }
}
