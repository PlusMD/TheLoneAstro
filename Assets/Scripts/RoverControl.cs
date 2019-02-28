using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverControl : MonoBehaviour {

	public GameObject player;
	public Transform playerSpawn;
	public GameObject roverDoorOpen;
	public GameObject roverDoorClose;
	public GameObject roverBodyOpen;
	public GameObject roverBodyClose;
	public GameObject roverCam;
	public Rigidbody roverPhysics;
	public RoverController roverMotor;
	public bool entered;
	public float enterCooldown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (entered == true) {
			if (Input.GetKeyDown (KeyCode.E) && enterCooldown <= 0) {
				ExitRover ();
			}
		}

		if (enterCooldown > 0) {
			enterCooldown -= Time.deltaTime;
		}
	}

	public void EnterRover(){
		entered = true;
		player.SetActive (false);
		roverDoorOpen.SetActive (false);
		roverDoorClose.SetActive (true);
		roverBodyOpen.SetActive (false);
		roverBodyClose.SetActive (true);
		roverCam.SetActive (true);
		roverMotor.enabled = true;
		roverPhysics.isKinematic = false;
	}

	void ExitRover(){
		entered = false;
		player.SetActive (true);
		player.transform.position = playerSpawn.position;
		roverDoorOpen.SetActive (true);
		roverDoorClose.SetActive (false);
		roverBodyOpen.SetActive (true);
		roverBodyClose.SetActive (false);
		roverCam.SetActive (false);
		roverMotor.enabled = false;
		roverPhysics.isKinematic = true;
	}
}
