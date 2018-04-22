using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitArea : MonoBehaviour
{
    public Queue<GameObject> arrowsInHitArea;
    //public List<GameObject> arrowsInHitArea;

    private void Start()
    {
        arrowsInHitArea = new Queue<GameObject>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        arrowsInHitArea.Enqueue(other.gameObject);
        other.gameObject.GetComponent<ArrowState>().isInHitArea = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<ArrowState>().active)
        {
            arrowsInHitArea.Dequeue();           
            other.gameObject.GetComponent<ArrowState>().active = false;
        }

        other.gameObject.GetComponent<ArrowState>().GotAfterHitArea();
        other.gameObject.GetComponent<ArrowState>().isInHitArea = false;
    }
}
