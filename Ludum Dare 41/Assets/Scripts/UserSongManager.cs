using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class UserSongManager : MonoBehaviour 
{
	// Variables
	private AudioSource source = null;

	// Constants
	private const string pathToMusicFolder = "../UserSongs/";
	private string[] possibleExtensions = new string[2] {"*.ogg", "*.wav"};

	void Awake()
	{
		//StartCoroutine(LoadAudioClip("https://raw.githubusercontent.com/jerry411/LudumDare41/master/UserSongs/Maxime%20Abbey%20-%20Green%20Hills.ogg"));
		GetFileNames();
	}
	private IEnumerator LoadAudioClip(string url)
	{
		WWW audioClipPath = new WWW(url);

		while(!audioClipPath.isDone)
		{
			yield return null;
		}

		source.clip = audioClipPath.GetAudioClip(true, false);
		if (!source.isPlaying && source.clip.loadState == AudioDataLoadState.Loaded)
		{
			source.Play();
		}    
	}
	private void GetFileNames()
	{
		string[] filePaths = new string[0];
		for(int i = 0; i < possibleExtensions.Length; i++)
		{
			string[] tempFilePaths = Directory.GetFiles(pathToMusicFolder, possibleExtensions[i]);
			filePaths = filePaths.Concat(tempFilePaths).ToArray();
		}

		for(int i = 0; i < filePaths.Length; i++)
		{
			Debug.Log(Path.GetFileName(filePaths[i]));
		}
	}
}