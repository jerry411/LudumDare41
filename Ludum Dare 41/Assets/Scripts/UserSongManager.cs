using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UserSongManager : MonoBehaviour 
{
	[SerializeField] AudioSource source;

	void Start()
	{
		StartCoroutine(loadAudioClip());
	}
	private IEnumerator loadAudioClip()
	{
		string path = "../UserSongs/";
		string fileExtension = "*.ogg";
		string[] filePaths = Directory.GetFiles(path, fileExtension);
		Debug.Log(filePaths[0]);

		List <AudioClip> audioClips = new List<AudioClip>();
		for(int i = 0; i < filePaths.Length; i++)
		{
			WWW audioClipDir = new WWW("https://github.com/jerry411/LudumDare41/blob/master/UserSongs/CaveChiptune.wav"); //+ filePaths[i]);
			//WWW audioClipDir = new WWW("../UserSongs/" + filePaths[i]);
			//WWW audioClipDir = new WWW(filePaths[i]);

			while(!audioClipDir.isDone)
			{
				yield return null;
			}
			audioClips.Add(audioClipDir.GetAudioClip());
			if(audioClips[i] == null)
			{
				Debug.Log("Fucking null");
			}
			SetAudioClip(audioClips[i]);
		}
	}
	private void SetAudioClip(AudioClip clip)
	{
		source.clip = clip;
		if(!source.isPlaying)
		{
			source.Play();
		}
	}
}