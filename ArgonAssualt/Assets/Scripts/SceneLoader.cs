﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("LoadScene", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
