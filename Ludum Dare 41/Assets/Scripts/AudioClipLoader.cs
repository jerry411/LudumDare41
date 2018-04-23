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
		if(GameInfo.Instance.isCustomSong)
		{
			StartCoroutine(LoadCustomAudioClip());
		}
	}
	public IEnumerator LoadCustomAudioClip()
	{
		string url = GameInfo.Instance.customSongUrl;
		WWW audioClipPath = new WWW(url);

		while(!audioClipPath.isDone)
		{
			yield return null;
		}


		AudioClip desiredAudioClip = audioClipPath.GetAudioClip(true, false);
		primarySource.clip = desiredAudioClip;
		if (!primarySource.isPlaying && primarySource.clip.loadState == AudioDataLoadState.Loaded)
		{
			primarySource.Play();
		}    
		secondarySource.clip = desiredAudioClip;
	}
}
