<<<<<<< HEAD
﻿using System.Collections;
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
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UserSongManager : MonoBehaviour 
{

}
>>>>>>> 4227842cd77509c3b695d0ea610e2e77291eb59b
