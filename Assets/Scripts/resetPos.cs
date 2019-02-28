using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetPos : MonoBehaviour {

	Collider ObjectCollider; 
	Vector3 pos; 

	// Use this for initialization
	void Start () {
		print (transform.position); 
		pos = transform.position; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(Collider ObjectCollider)
	{
		transform.position = pos; 
	}

}
