using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Kart", menuName = "Karts")]
public class Karts : ScriptableObject {
    public float thrust = 150f;
    Rigidbody2D rb;

    public void MoveAhead(GameObject go)
    {
        rb = go.GetComponent<Rigidbody2D>();
        rb.AddForce(rb.gameObject.transform.right * thrust);
    }
}
