using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGround : MonoBehaviour {

	RaycastHit hit;

	// Use this for initialization
	void Start () {
		if (Physics.Raycast (transform.position, -Vector3.up, out hit)) {
			transform.position = hit.point;
		}
	}
}
