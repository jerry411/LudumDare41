using UnityEngine.UI;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{

    public float distanceTravelled = 0f;
    public int simpleDist;
    public Vector2 lastPos;
    public Text distText;
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> parent of 60803eb... Score display at EndGame scene
    public ArrowGenerator gen;
    public Text disttextEnd;
    GameObject playerCar;
=======
    public GameObject mainSongSource;
    public GameObject playerCar;
    public Text songName;

<<<<<<< HEAD
    private AudioSource audioSource;

>>>>>>> b46a5ea36253a58b05a70e1db6dbd868fc55d331

    void Start ()
=======
	// Use this for initialization
	void Start ()
>>>>>>> parent of 60803eb... Score display at EndGame scene
    {
        playerCar = GameObject.FindGameObjectWithTag("Player");
        lastPos = playerCar.transform.position;
<<<<<<< HEAD

        audioSource = mainSongSource.GetComponent<AudioSource>();

        songName.text = PlayerPrefs.GetString("SongName", "...");
    }
=======
	}
>>>>>>> parent of 60803eb... Score display at EndGame scene
	
	// Update is called once per frame
	void Update ()
    {
<<<<<<< HEAD
        if (audioSource.isPlaying)
        {
            distanceTravelled += Vector2.Distance(lastPos, playerCar.transform.position);
        }

        if ((Math.Abs(audioSource.time - audioSource.clip.length) < 0.001) || Input.GetKeyDown(KeyCode.F3))    //F3 for DEBUG only
        {
            PlayerPrefs.SetFloat("DistanceTravelled", distanceTravelled);
            SceneManager.LoadScene(3);
=======
        DontDestroyOnLoad(gameObject);

        if (gen.mainSongSource.isPlaying)
            distanceTravelled += Vector2.Distance(lastPos, playerCar.transform.position);
        else
>>>>>>> parent of 60803eb... Score display at EndGame scene
            return;

        simpleDist = ((int)(distanceTravelled)) / 1000;
        distText.text = simpleDist.ToString();
	}
}
