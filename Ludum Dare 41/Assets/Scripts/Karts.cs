using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karts {
    float thrust = 15f;
    Rigidbody2D rb;

    public void MoveAhead()
    {
        rb.AddForce(rb.gameObject.transform.right * thrust);
    }

    public Karts(GameObject go)
    {
        rb = go.GetComponent<Rigidbody2D>();
    }
}
