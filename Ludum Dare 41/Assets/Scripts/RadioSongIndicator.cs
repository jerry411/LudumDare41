using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadioSongIndicator : MonoBehaviour
{
    public Slider songIndicator;
    public AudioSource audioSource;

    void Update ()
    {
        songIndicator.value = audioSource.time / audioSource.clip.length;
    }
}
