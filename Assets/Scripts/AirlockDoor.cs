using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirlockDoor : MonoBehaviour {

	public Animator animator;
	public bool locked = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (locked == false) {
			if (other.tag == "Player") {
				animator.SetBool ("Open", true);
			}
		}

		if (locked == true) {
			if (other.tag == "Objects") {
				locked = false;
			}
		}
	}

	void OnTriggerExit (Collider other) {
		if (locked == false) {
			if (other.tag == "Player") {
				animator.SetBool ("Open", false);
			}
		}
	}
}
