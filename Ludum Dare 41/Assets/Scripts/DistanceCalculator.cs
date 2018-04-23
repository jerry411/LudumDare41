using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DistanceCalculator : MonoBehaviour
{

    public float distanceTravelled = 0f;
    public int simpleDist;
    public Vector2 lastPos;
    public Text distText;
    public GameObject mainSongSource;
    public Text disttextEnd;
    public GameObject playerCar;

    private AudioSource audioSource;


    void Start ()
    {
        lastPos = playerCar.transform.position;

        audioSource = mainSongSource.GetComponent<AudioSource>();
    }
	
	void Update ()
    {
        //DontDestroyOnLoad(gameObject);

        if (audioSource.isPlaying)
        {
            distanceTravelled += Vector2.Distance(lastPos, playerCar.transform.position);
        }            
        else if ((Math.Abs(audioSource.time - audioSource.clip.length) < 0.001))
        {
            Debug.Log(distanceTravelled);
            PlayerPrefs.SetFloat("DistanceTravelled", distanceTravelled);
            SceneManager.LoadScene(3);
            return;
        }

        if (Input.GetKeyDown(KeyCode.F3))   // DEBUG ONLY
        {
            Debug.Log(distanceTravelled);
            PlayerPrefs.SetFloat("DistanceTravelled", distanceTravelled);
            SceneManager.LoadScene(3);
            return;
        }


        simpleDist = ((int)(distanceTravelled)) / 1000;
        distText.text = simpleDist.ToString();
	}
}
