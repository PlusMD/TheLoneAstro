using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

	bool engine = false;
	bool computer = false;
	bool landingGear = false;
	bool launch = false;

	public Rigidbody rigidbody;
	public float Thrust = 3f; 

	public GameObject player;
	public GameObject camera;
	public GameObject fire;

	public PlayerStats stats;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (launch == true) {
			Thrust += Time.deltaTime * 2;
			rigidbody.AddRelativeForce (transform.up * Thrust);
			if (Input.GetKey (KeyCode.W)) {
				rigidbody.AddRelativeForce (transform.forward * 2);
			}

			if (Input.GetKey (KeyCode.A)) {
				rigidbody.AddRelativeForce (transform.right * 2);
			}

			if (Input.GetKey (KeyCode.S)) {
				rigidbody.AddRelativeForce (-transform.forward * 2);
			}

			if (Input.GetKey (KeyCode.D)) {
				rigidbody.AddRelativeForce (-transform.right * 2);
			}

			if (engine == false) {
				rigidbody.AddRelativeForce (-transform.right * 0.3f);
			}

			if (computer == false) {
				rigidbody.AddRelativeForce (-transform.forward * 0.3f);
			}

			if (landingGear == false) {
				rigidbody.AddRelativeForce (-transform.forward * 0.7f);
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Rocket Part") {
			if (other.GetComponent<CogID> ().ID == 1) {
				engine = true;
			}

			if (other.GetComponent<CogID> ().ID == 2) {
				computer = true;
			}

			if (other.GetComponent<CogID> ().ID == 3) {
				landingGear = true;
			}
		}

		if (launch == true) {
			stats.O2 = 0;
			stats.O2Tanks = 0;
		}
	}

	void OnTriggerStay (Collider other) {
		if (other.tag == "Player") {
			if (Input.GetKeyDown (KeyCode.E)) {
				launchRocket ();
			}
		}
	}

	void launchRocket(){
		launch = true;
		fire.SetActive(true);
		player.SetActive (false);
		camera.SetActive (true);
	}
}
