using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HitArea : MonoBehaviour
{
    public Queue<GameObject> arrowsInHitArea;

    void Start()
    {
        arrowsInHitArea = new Queue<GameObject>();

        float newDifficulty = PlayerPrefs.GetFloat("Difficulty", 0.5f);
        SetDifficulty(newDifficulty);
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

    private float maxWidth = 250;
    private float minWidth = 50;

    void SetDifficulty(float difficulty)
    {
        //Debug.Log(difficulty);

        float newWidth = maxWidth - ((maxWidth - minWidth) * difficulty);

        RectTransform rectTransform = this.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(newWidth, rectTransform.sizeDelta.y);

        BoxCollider2D thisCollider = this.GetComponent<BoxCollider2D>();
        thisCollider.size = new Vector2(newWidth, thisCollider.size.y); ;
    }
}
