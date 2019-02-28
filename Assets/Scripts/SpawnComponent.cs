using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnComponent : MonoBehaviour {

	public GameObject objectToEnable;

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Cogs") {
			objectToEnable.SetActive (true);
		}
	}
}
