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
    public GameObject playerCar;
    public Text songName;

    private AudioSource audioSource;


    void Start ()
    {
        lastPos = playerCar.transform.position;

        audioSource = mainSongSource.GetComponent<AudioSource>();

        songName.text = PlayerPrefs.GetString("SongName", "...");
    }
	
	void Update ()
    {
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
