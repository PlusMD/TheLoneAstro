using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverEnter : MonoBehaviour {

	public RoverControl roverControl;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerStay (Collider other) {
		if (other.tag == "Player" && Input.GetKeyDown (KeyCode.E)) {
			roverControl.EnterRover ();
			roverControl.enterCooldown = 1.0f;
		}
	}
}
