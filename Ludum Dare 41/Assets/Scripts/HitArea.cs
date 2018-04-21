using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    public List<GameObject> arrowsInHitArea;

    private void Start()
    {
        arrowsInHitArea = new List<GameObject>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        arrowsInHitArea.Add(other.gameObject);
        other.gameObject.GetComponent<ArrowState>().isInHitArea = true;
    }
}
