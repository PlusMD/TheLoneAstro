using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour {

	void OnTriggerEnter (Collider other) {
		if (other.GetComponent<canPickUp> ()) {
			other.GetComponent<canPickUp> ().ResetPosition ();
		}
	}
}
