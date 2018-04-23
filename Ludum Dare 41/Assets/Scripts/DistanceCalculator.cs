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
        /*GameObject[] allCars = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject car in allCars)
        {
            if (car != null)
            {
                playerCar = car;
                break;
            }
        }*/

        //playerCar = GameObject.FindGameObjectWithTag("Player");
        //lastPos = playerCar.transform.position;

        audioSource = mainSongSource.GetComponent<AudioSource>();

        songName.text = PlayerPrefs.GetString("SongName", "...");
    }
	
	void Update ()
    {
        if (playerCar == null)
        {
            return;
        }

        if (audioSource.isPlaying)
        {
            distanceTravelled += Vector2.Distance(lastPos, playerCar.transform.position);
        }

        if ((Math.Abs(audioSource.time - audioSource.clip.length) < 0.001) || Input.GetKeyDown(KeyCode.F3))    //F3 for DEBUG only
        {
            PlayerPrefs.SetFloat("DistanceTravelled", distanceTravelled);
            SceneManager.LoadScene(3);
            return;
        }


        simpleDist = ((int)(distanceTravelled)) / 1000;
        distText.text = simpleDist.ToString();
	}

    public void SetPlayerCar(GameObject car)
    {
        playerCar = car;
        lastPos = playerCar.transform.position;
    }
}
