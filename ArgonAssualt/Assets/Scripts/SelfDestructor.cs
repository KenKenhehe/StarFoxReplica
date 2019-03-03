using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructor : MonoBehaviour {
    float existedTime = 3f;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, existedTime);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
