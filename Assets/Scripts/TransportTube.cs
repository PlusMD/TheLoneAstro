using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportTube : MonoBehaviour {

	public Animator animator;
	public List<Rigidbody> components = new List<Rigidbody> ();
	public bool send = false;
	public Transform receptor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (send == true) {
			TeleportItems ();
			send = false;
		}
	}

	public void SendItems (){
		animator.SetTrigger ("SendItems");
	}

	void TeleportItems(){
		foreach (Rigidbody item in components) {
			item.transform.position = receptor.position;
			print (item.position);
		}

		components.Clear();
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Component") {
			components.Add (other.GetComponent<Rigidbody> ());
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Component") {
			components.Remove (other.GetComponent<Rigidbody> ());
		}
	}
}
