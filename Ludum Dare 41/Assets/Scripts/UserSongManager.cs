using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UserSongManager : MonoBehaviour 
{
	void Start()
	{
		StartCoroutine(loadAudioClip());
	}
	private IEnumerator loadAudioClip()
	{
		string path = "../UserSongs/";
		string fileExtension = "*.wav";
		string[] filePaths = Directory.GetFiles(path, fileExtension);
		Debug.Log(filePaths[0]);

		List <AudioClip> audioClips = new List<AudioClip>();
		for(int i = 0; i < filePaths.Length; i++)
		{
			WWW audioClipDir = new WWW("file://" + filePaths[i]);

			while(!audioClipDir.isDone)
			{
				yield return null;
			}
			//audioClips.Add(audioClipDir.audioClip)
		}
	}
<<<<<<< HEAD
}

=======
}
>>>>>>> ad7d860e7bd6f1ac8b36e66c8d23a2a49f9461d2
