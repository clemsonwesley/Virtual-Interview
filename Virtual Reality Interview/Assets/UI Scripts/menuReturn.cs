﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuReturn: MonoBehaviour {

	public void PlayGame(){
		Time.timeScale = 1.0f;
		SceneManager.LoadScene(1);
	}
}
