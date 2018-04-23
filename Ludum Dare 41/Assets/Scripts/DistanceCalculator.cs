using UnityEngine.UI;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{

    public float distanceTravelled = 0f;
    public int simpleDist;
    public Vector2 lastPos;
    public Text distText;
    public ArrowGenerator gen;
    public Text disttextEnd;
    GameObject playerCar;

	// Use this for initialization
	void Start ()
    {
        playerCar = GameObject.FindGameObjectWithTag("Player");
        lastPos = playerCar.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        DontDestroyOnLoad(gameObject);

        if (gen.mainSongSource.isPlaying)
            distanceTravelled += Vector2.Distance(lastPos, playerCar.transform.position);
        else
            return;

        simpleDist = ((int)(distanceTravelled)) / 1000;
        distText.text = simpleDist.ToString();
	}
}
