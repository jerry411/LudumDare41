using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public AudioProcessor processor;

    public AudioSource mainSongSource;

    public ArrowVisualiser visualiser;      


    void Start ()
	{
	    processor.onBeat.AddListener(onBeatDetected);
	    //processor.onSpectrum.AddListener(onSpectrum);	    

	    mainSongSource.PlayDelayed(2);
	}

    //This event will be called every time a beat is detected.
    //Change the threshold parameter in the inspector to adjust the sensitivity
    void onBeatDetected()
    {
        //Debug.Log(selectRandomArrow());

        visualiser.spawnArrow(selectRandomArrow());
    }

    //This event will be called every frame while music is playing
    /*void onSpectrum(float[] spectrum)
    {
        for (int i = 0; i < spectrum.Length; ++i)
        {
            Debug.Log(spectrum[i]);
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end   = new Vector3(i, spectrum[i], 0);
            Debug.DrawLine(start, end);
        }
    }*/

    int selectRandomArrow()
    {
        return Random.Range(0, 4);
    }  
}
