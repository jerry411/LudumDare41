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
	[SerializeField] private LoadingScreen loadingScreen;
	[SerializeField] private GameObject canvasObj;

	// Constants
	private const string pathToMusicFolder = "../UserSongs/";
	private const string wwwPathToMusicFolder = "../../../UserSongs/";
	private string[] possibleExtensions = new string[2] {"*.ogg", "*.wav"};
	private const int mainSceneIndex = 2;

	// CUSTOM SONG SELECTION
	// This is bad practice
	// I didn't have time
	// Don't judge me...
	[SerializeField] GameObject customSongButton1;
	[SerializeField] GameObject customSongButton2;
	[SerializeField] GameObject customSongButton3;
	[SerializeField] GameObject customSongButton4;
	[SerializeField] GameObject customSongButton5;
	List <GameObject> customSongButtonList = new List <GameObject>();
	private const int customSongLimit = 5;

	void Start()
	{
		addCustomSongButtonsToList();
		DisplayCustomsSongsInList();
	}
	public void LoadCustomAudioClipWrapper(int index)
	{
		StartCoroutine(LoadCustomAudioClip(index));
	}
	private IEnumerator LoadCustomAudioClip(int index)
	{
		HideUI();
		string url = "file:///" + Application.dataPath + wwwPathToMusicFolder + fileNames[index];
		WWW audioClipPath = new WWW(url);

		while(!audioClipPath.isDone)
		{
			yield return null;
		}

	    PlayerPrefs.SetString("SongName", fileNames[index]);

        GameInfo.Instance.audioClip = audioClipPath.GetAudioClip(true, false);
		loadingScreen.LoadLevel(mainSceneIndex);
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
		Debug.Log(fileNames.Count);
		for(int i = 0; i < fileNames.Count; i++)
		{
			if(i > customSongLimit)
			{
				return;
			}
			customSongButtonList[i].SetActive(true);
			customSongButtonList[i].GetComponentInChildren<Text>().text = fileNames[i];
		}
	}
	public void LoadSongFromRessources(AudioClip clip)
	{
		GameInfo.Instance.audioClip = clip;
	    PlayerPrefs.SetString("SongName", clip.name);
    }
	private void addCustomSongButtonsToList()
	{
		// Seriously... I was kind of desperate to get this done...
		if(customSongButton1 != null)
		{
			customSongButtonList.Add(customSongButton1);
		}
		if(customSongButton2 != null)
		{
			customSongButtonList.Add(customSongButton2);
		}
		if(customSongButton3 != null)
		{
			customSongButtonList.Add(customSongButton3);
		}
		if(customSongButton4 != null)
		{
			customSongButtonList.Add(customSongButton4);
		}
		if(customSongButton5 != null)
		{
			customSongButtonList.Add(customSongButton5);
		}
	}
	private void HideUI()
	{
		canvasObj.SetActive(false);
	}
}