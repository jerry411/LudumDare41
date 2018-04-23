using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class UserSongManager : MonoBehaviour 
{
	// Variables
	private List <string> fileNames = new List <string>();

	// Constants
	private const string pathToMusicFolder = "../UserSongs/";
	private const string wwwPathToMusicFolder = "../../../UserSongs/";
	private string[] possibleExtensions = new string[2] {"*.ogg", "*.wav"};
	private const int mainSceneIndex = 2;
	private const int customSongLimit = 5;

	void Start()
	{
		DisplayCustomsSongsInList();
		SetCustomSong(0);
	}
	public void LoadCustomAudioClipWrapper(int index)
	{
		StartCoroutine(LoadCustomAudioClip(index));
	}
	private IEnumerator LoadCustomAudioClip(int index)
	{
		string url = "file:///" + Application.dataPath + wwwPathToMusicFolder + fileNames[index];
		WWW audioClipPath = new WWW(url);

		while(!audioClipPath.isDone)
		{
			yield return null;
		}

		GameInfo.Instance.audioClip = audioClipPath.GetAudioClip(true, false);

		/*
		source.clip = audioClipPath.GetAudioClip(true, false);
		if (!source.isPlaying && source.clip.loadState == AudioDataLoadState.Loaded)
		{
			source.Play();
		}    
		*/
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
		for(int i = 0; i < fileNames.Count; i++)
		{
			if(i > customSongLimit)
			{
				return;
			}
			// activate button with index i
		}
	}
	public void SetCustomSong(int index)
	{
		/*
		GameInfo.Instance.isCustomSong = true;
		string url = "file:///" + Application.dataPath + wwwPathToMusicFolder + fileNames[index];
		GameInfo.Instance.customSongUrl = url;
		*/
	}
	public void LoadSongFromRessources(AudioClip clip)
	{
		GameInfo.Instance.audioClip = clip;
	}
}