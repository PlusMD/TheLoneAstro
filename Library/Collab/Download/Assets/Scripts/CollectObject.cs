using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObject : MonoBehaviour {

	GameObject mainCamera;
	public PlayerStats playerStats;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.E)) {
			Interact ();
		}
	}

	void Interact(){
		int x = Screen.width / 2;
		int y = Screen.height / 2;

		Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit)) {
			if (hit.transform.tag == "Oxygen") {
				playerStats.O2Tanks += 1;
				Destroy (hit.transform.gameObject);
			}

			if (hit.transform.tag == "Button") {
				hit.transform.GetComponent<TransportTube> ().SendItems ();
			}


			if (hit.transform.tag == "OtherButton") {
				hit.transform.GetComponent<AddForce> ().fuckoff (); 
			}

			if (hit.transform.tag == "CogButton") {
				hit.transform.GetComponent<CogDropButton> ().DropAllCogs ();
			}
		}
	}
}

