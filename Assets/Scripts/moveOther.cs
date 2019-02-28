using UnityEngine; 
using System.Collections;

public class moveOther : MonoBehaviour { 

	public Rigidbody rigidbody;
	Collider ObjectCollider; 

	void Start ()
	{
		//rigidbody = GetComponent<Rigidbody>();
		ObjectCollider = GetComponent<Collider> (); 
		ObjectCollider.isTrigger = true;
	}

	void OnTriggerEnter (Collider other) 
	{
		if(other.tag == "Objects")
		{
			rigidbody.useGravity = true;
			rigidbody.isKinematic = false;
			ObjectCollider.isTrigger = false; 

		}
	}
}
