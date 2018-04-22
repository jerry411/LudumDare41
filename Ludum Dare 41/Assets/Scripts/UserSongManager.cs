using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class UserSongManager : MonoBehaviour 
{
	// Variables
	private AudioSource source = null;
	private List <string> fileNames = new List <string>();

	// Constants
	private const string pathToMusicFolder = "../UserSongs/";
	private const string wwwPathToMusicFolder = "../../../UserSongs/";
	private string[] possibleExtensions = new string[2] {"*.ogg", "*.wav"};

	void Awake()
	{
		source = GetComponent<AudioSource>();

		StartCoroutine(LoadAudioClip(0));	
	}
	private IEnumerator LoadAudioClip(int index)
	{
		string url = "file:///" + Application.dataPath + wwwPathToMusicFolder + fileNames[index];
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
	private List <string> GetFileNames()
	{
		List <string> localFileNames = new List <string>();
		string[] filePaths = new string[0];

		for(int i = 0; i < possibleExtensions.Length; i++)
		{
			string[] tempFilePaths = Directory.GetFiles(pathToMusicFolder, possibleExtensions[i]);
			filePaths = filePaths.Concat(tempFilePaths).ToArray();
		}

		for(int i = 0; i < filePaths.Length; i++)
		{
			Debug.Log(Path.GetFileName(filePaths[i]));
			localFileNames.Add(Path.GetFileName(filePaths[i]));
		}
		return localFileNames;
	}
	private void DisplayCustomsSongsInList()
	{
		fileNames = GetFileNames();
	}
}