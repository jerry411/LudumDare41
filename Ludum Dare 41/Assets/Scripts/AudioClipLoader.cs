using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClipLoader : MonoBehaviour 
{
	// Variables
	[SerializeField] private AudioSource primarySource;
	[SerializeField] private AudioSource secondarySource;

	void Start()
	{
		SetAudioClip(primarySource);
		SetAudioClip(secondarySource);
	}
	private void SetAudioClip(AudioSource source)
	{
		source.clip = GameInfo.Instance.audioClip;
		if (!source.isPlaying && source.clip.loadState == AudioDataLoadState.Loaded)
		{
			source.Play();
		}    
	}
}
