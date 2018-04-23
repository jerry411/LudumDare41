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
		SetAudioClips();
	}
	private void SetAudioClips()
	{
		primarySource.clip = GameInfo.Instance.audioClip;
		secondarySource.clip = GameInfo.Instance.audioClip;
	}
}
