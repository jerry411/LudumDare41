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
<<<<<<< HEAD
    public ArrowGenerator gen;
    public Text disttextEnd;
<<<<<<< HEAD
    GameObject playerCar;
=======
    public GameObject mainSongSource;
    public GameObject playerCar;
    public Text songName;

    private AudioSource audioSource;

>>>>>>> b46a5ea36253a58b05a70e1db6dbd868fc55d331
=======
    public GameObject playerCar;
>>>>>>> parent of a91eedb... Changed a lot of stuff

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

        if ((Math.Abs(audioSource.time - audioSource.clip.length) < 0.001) || Input.GetKeyDown(KeyCode.F3))    //F3 for DEBUG only
        {
            PlayerPrefs.SetFloat("DistanceTravelled", distanceTravelled);
            SceneManager.LoadScene(3);
            return;
        }


        simpleDist = ((int)(distanceTravelled)) / 1000;
        distText.text = simpleDist.ToString();
	}
}
