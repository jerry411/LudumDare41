using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{

    public static bool gamePaused = false;
    public GameObject pauseMenuCanvas;

    public GameObject songSource;
    public GameObject arrowGenerator;

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
                Resume();
            else
                Pause();
        }
	}

    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        gamePaused = false;

        songSource.GetComponent<AudioSource>().UnPause();
        arrowGenerator.GetComponent<AudioSource>().UnPause();
    }

    public void Pause()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0.0f;
        gamePaused = true;

        
        songSource.GetComponent<AudioSource>().Pause();
        arrowGenerator.GetComponent<AudioSource>().Pause();
    }
}
