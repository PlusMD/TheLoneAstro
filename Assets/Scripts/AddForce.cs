using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour {


	public float thrust = 10000; 
	public Rigidbody rigidbody;
	//Collider ObjectCollider; 


	void Start ()
	{
		//rigidbody = GetComponent<Rigidbody>();
		//ObjectCollider = GetComponent<Collider> (); 

		//ObjectCollider.isTrigger = true;
	}


	/*
	void OnTriggerEnter (Collider other) 
	{
		if(other.tag == "Objects")
		{
			rigidbody.useGravity = false;
			rigidbody.isKinematic = false;
			rigidbody.AddForce (transform.up * thrust); 
			ObjectCollider.isTrigger = false; 

		}
	}

	*/ 

	public void fuckoff(){
		//rigidbody = GetComponent<Rigidbody>();

		rigidbody.AddForce (transform.up * thrust); 
	}


}
