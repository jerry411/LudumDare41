using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Kart", menuName = "Karts")]
public class Karts : ScriptableObject {
    public float thrust = 15f;
    public float accelerationThrust = 5f;
    public float malusThrust = -10f;
    Rigidbody2D rb;

    public void MoveAhead(GameObject go)
    {
        rb = go.GetComponent<Rigidbody2D>();
        rb.AddForce(go.transform.right * thrust);
    }

    public void StreakBoost(GameObject go)
    {
        rb = go.GetComponent<Rigidbody2D>();
        rb.drag -= 0.2f;
        rb.AddForce(rb.gameObject.transform.right * accelerationThrust);
    }

    public void StreakSlowDown(GameObject go)
    {
        rb = go.GetComponent<Rigidbody2D>();
        rb.drag += 0.2f;
        rb.AddForce((-rb.gameObject.transform.right) * accelerationThrust);
    }

    public void MalusSlow(GameObject go)
    {
        rb = go.GetComponent<Rigidbody2D>();
        rb.drag += 0.4f;
        rb.AddForce(rb.gameObject.transform.right * malusThrust);
    }

    public void MalusFastAgain(GameObject go)
    {
        rb = go.GetComponent<Rigidbody2D>();
        rb.drag -= 0.4f;
        rb.AddForce(-rb.gameObject.transform.right * malusThrust);
    }

}
