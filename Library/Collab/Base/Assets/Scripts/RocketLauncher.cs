using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour {

	Rigidbody rigidbody;
	public float Thrust = 3f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		update ();
	}

	void update()
	{
		rigidbody.AddForce (transform.up * Thrust);
	}
}
