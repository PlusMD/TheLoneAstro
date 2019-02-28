using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsPuz : MonoBehaviour {


	public GameObject button1;
	public GameObject button2;
	public GameObject button3;
	public GameObject button4;

	public GameObject drop; 

	public float totalButt;

	// Use this for initialization
	void Start () {
		drop.SetActive (false); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		totalButt = button1.GetComponent<puzzleGame> ().pressed + button2.GetComponent<puzzleGame> ().pressed + button3.GetComponent<puzzleGame> ().pressed + button4.GetComponent<puzzleGame> ().pressed;

		if (totalButt == 4) {
			drop.SetActive (true); 
		
		}

	}
}
