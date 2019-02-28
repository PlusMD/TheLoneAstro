using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour {

	public GameObject WinUI;
	public Animator rocketAnimator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Rocket") {
			WinUI.SetActive (true);
			rocketAnimator.SetTrigger ("Win");
		}
	}
}
