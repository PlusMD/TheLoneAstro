using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCard : MonoBehaviour {

	public ParticleSystem red; 
	public ParticleSystem green; 

	Collider ObjectCollider; 



	// Use this for initialization
	void Start () {

		ObjectCollider = GetComponent<Collider> (); 

	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Objects") {
			green.Play ();
		} 
		else 
		{
			red.Play (); 
		}
	}

}
