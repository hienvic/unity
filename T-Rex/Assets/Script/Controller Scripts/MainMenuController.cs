﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
	{
		Application.LoadLevel("Game");
	}
	public void ResumeGame()
	{
		Application.LoadLevel("Game");
	}
}
