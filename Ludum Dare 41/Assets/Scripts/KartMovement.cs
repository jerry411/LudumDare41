using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KartMovement : MonoBehaviour {

    public Karts kart;
    public Text speedText;
    Rigidbody2D rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate ()
    {
        kart.MoveAhead(gameObject);
    }

    private void Update()
    {
        speedText.text = ((int)(rb.velocity.magnitude * 10 - 10)).ToString();
    }
}
