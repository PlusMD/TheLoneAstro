using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleGame : MonoBehaviour {


	public bool correctButton; 
	bool prevPressed; 
	public GameObject drop; 

	//int correctButtonsPressed = 0; 
	public int pressed = 0; 

	public ParticleSystem red; 
	public ParticleSystem green; 
	// Use this for initialization
	void Start () {
		//print (correctButtonsPressed); 

		drop.SetActive (false); 
	}
	
	// Update is called once per frame
	void Update () {
		if (pressed == 3)
		{
			drop.SetActive (true); 

		} 
	}

	public void buttonPressed(){


		if (correctButton == true) {
			bool prevPressed = true; 
			correctButton = false; 
//			green.Play; 
			pressed++; 
			print ("Number " + pressed); 
		}



	}
}
