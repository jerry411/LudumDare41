﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour 
{
	public static GameInfo Instance { get; set; }

	// TODO: This also needs a car selection.
	public bool isCustomSong;
	public string customSongUrl;

	void Awake()
	{
		if(Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}
}
