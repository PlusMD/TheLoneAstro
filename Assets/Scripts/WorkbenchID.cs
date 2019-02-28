using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkbenchID : MonoBehaviour {

	public int componentID;
	public int workbenchID;
	public Workbench workbench;
	public GameObject onPad;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Component" && other.GetComponent<ComponentID> ().ID == componentID) {
			workbench.parts [workbenchID - 1].SetActive (true);
			workbench.collectedParts += 1;
			onPad.SetActive (true);
			gameObject.SetActive (false);
			Destroy (other.transform.gameObject);
		}
	}
}
