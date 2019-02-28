using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canPickUp : MonoBehaviour {

	Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	public void ResetPosition () {
		transform.position = startPosition;
	}
}
