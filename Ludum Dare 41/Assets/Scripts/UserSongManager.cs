using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UserSongManager : MonoBehaviour 
{
	void Start()
	{
		string path = "../UserSongs/";
		string fileExtension = "*.wav";
		string[] filePaths = Directory.GetFiles(path, fileExtension);
		Debug.Log(filePaths[0]);
	}
}
