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
	    //processor.onSpectrum.AddListener(onSpectrum);	    

	    mainSongSource.PlayDelayed(2f);

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
        //visualiser.spawnArrow(getArrowTypeBasedOnSpectrum(currentSpectrum));

        //Debug.Log(String.Format("{0}  {1}  {2}  {3}  {4}  {5}  {6}  {7}  {8}  {9}  {10}  {11}", currentSpectrum[0] * 10000
        //                        , currentSpectrum[1] * 10000, currentSpectrum[2] * 10000, currentSpectrum[3] * 10000, currentSpectrum[4] * 10000, currentSpectrum[5] * 10000, currentSpectrum[6] * 10000
        //                        , currentSpectrum[7] * 10000, currentSpectrum[8] * 10000, currentSpectrum[9] * 10000, currentSpectrum[10] * 10000, currentSpectrum[11] * 10000));
    }

    private int getArrowTypeBasedOnSpectrum(float[] spectrum)
    {
        if (spectrum == null)
        {
            return 0;
        }

        float biggestChange = float.MinValue;
        int indexOfBiggestChange = 0;

        for (int i = 0; i < spectrum.Length; i++)
        {
            if (spectrum[i] > biggestChange)
            {
                biggestChange = spectrum[i];
                indexOfBiggestChange = i;
            }
        }

        Debug.Log(indexOfBiggestChange / 3);

        return indexOfBiggestChange / 3;
    }   

    //This event will be called every frame while music is playing
    void onSpectrum(float[] spectrum)
    {
        //currentSpectrum = spectrum;

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
