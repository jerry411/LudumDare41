using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UserSongManager : MonoBehaviour 
{
	[SerializeField] AudioSource source = null;

	void Start()
	{
		StartCoroutine(loadAudioClip("https://raw.githubusercontent.com/jerry411/LudumDare41/master/UserSongs/Maxime%20Abbey%20-%20Green%20Hills.ogg"));
	}
	private IEnumerator loadAudioClip(string url)
	{
		WWW audioClipPath = new WWW(url);

		while(!audioClipPath.isDone)
		{
			yield return null;
		}
		Debug.Log(audioClipPath.bytesDownloaded);
		source.clip = audioClipPath.GetAudioClip(true, false);
		if (!source.isPlaying && source.clip.loadState == AudioDataLoadState.Loaded)
		{
			source.Play();
		}    

	}
}