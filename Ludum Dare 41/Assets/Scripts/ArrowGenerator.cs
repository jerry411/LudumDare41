using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class ArrowGenerator : MonoBehaviour
{
    public AudioProcessor processor;

    public AudioSource mainSongSource;

    public ArrowVisualiser visualiser;

    private DateTime lastBeat;

    void Start ()
	{
	    processor.onBeat.AddListener(onBeatDetected);
	    processor.onSpectrum.AddListener(onSpectrum);	    

	    mainSongSource.PlayDelayed(2);

	    lastBeat = DateTime.MinValue;
	}

    //This event will be called every time a beat is detected.
    //Change the threshold parameter in the inspector to adjust the sensitivity
    void onBeatDetected()
    {
        //Debug.Log(DateTime.Now.Subtract(lastBeat).Milliseconds);

        if (DateTime.Now.Subtract(lastBeat).Milliseconds < 250)
        {
            return;
        }

        lastBeat = DateTime.Now;
        visualiser.spawnArrow(selectRandomArrow());

        Debug.Log(String.Format("{0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}  {8}  {9}  {10}  {11}", lastSpectrum[0]
                                , lastSpectrum[1], lastSpectrum[2], lastSpectrum[3], lastSpectrum[4], lastSpectrum[5], lastSpectrum[6]
                                , lastSpectrum[7], lastSpectrum[8], lastSpectrum[9], lastSpectrum[10], lastSpectrum[11]));
    }

    float[] lastSpectrum;

    //This event will be called every frame while music is playing
    void onSpectrum(float[] spectrum)
    {
        lastSpectrum = spectrum;

        for (int i = 0; i < spectrum.Length; ++i)
        {
            //Debug.Log(spectrum.Length);
            Vector3 start = new Vector3(i, 0, 0);
            Vector3 end   = new Vector3(i, spectrum[i], 0);
            Debug.DrawLine(start, end);
        }
    }

    int selectRandomArrow()
    {
        return Random.Range(0, 4);
    }  
}
