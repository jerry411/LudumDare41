using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource audio;
    public bool playClickSoundAtInit = false;

    private void Start()
    {
        if (playClickSoundAtInit)
        {
            audio.Play();
        }
    }

    public void playSound()
    {
        audio.Play();
    }
}
