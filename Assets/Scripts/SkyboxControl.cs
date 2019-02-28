using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		SetNight ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SetNight(){
		RenderSettings.skybox.SetFloat ("_Exposure", 0f);
	}

	void SetDay(){
		RenderSettings.skybox.SetFloat ("_Exposure", 1.3f);
	}
}
