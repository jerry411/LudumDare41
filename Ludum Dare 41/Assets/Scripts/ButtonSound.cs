using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource thisAudio;
    public bool playClickSoundAtInit = false;

    private void Start()
    {
        if (playClickSoundAtInit)
        {
            thisAudio.Play();
        }
    }

    public void playSound()
    {
        thisAudio.Play();
    }
}
