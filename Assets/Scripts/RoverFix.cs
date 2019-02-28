using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverFix : MonoBehaviour {

	public int componentID;
	public GameObject roverStandin;
	public GameObject rover;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Component" && other.GetComponent<ComponentID> ().ID == componentID) {
			Destroy (other.transform.gameObject);
			roverStandin.SetActive (false);
			rover.SetActive (true);
		}
	}
}
