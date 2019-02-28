using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogRecognition : MonoBehaviour {

	public bool hasCog = false;
	public Transform cogPosition;
	public pickUpObject objectPickupScript;
	public GameObject cog;
	int cogSize;
	public int requiredCogID;
	public GameObject cogToTrigger;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Cogs" && hasCog == false) {
			objectPickupScript.dropObject ();
			other.GetComponent<Rigidbody> ().isKinematic = true;
			other.transform.position = cogPosition.position;
			other.transform.rotation = cogPosition.rotation;
			cog = other.gameObject;
			hasCog = true;
			cog.transform.parent = cogPosition;
			cogSize = cog.GetComponent<CogID> ().ID;
			Destroy (cog.GetComponent<canPickUp> ());
			if (cogSize == requiredCogID) {
				cogToTrigger.GetComponent<CogTrigger> ().CogCheck ();
			}
		}
	}

	public void DropCogs(){
		cog.AddComponent<canPickUp> ();
		cog.GetComponent<Rigidbody> ().isKinematic = false;
		cog.transform.parent = null;
		cog = null;
		hasCog = false;
	}
}
