using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : MonoBehaviour {

	public GameObject[] parts;
	public int collectedParts = 0;
	bool spawned = false;
	public GameObject finishedComponent;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (collectedParts == 3 && spawned == false) {
			finishedComponent.SetActive (true);
			foreach (var part in parts) {
				part.SetActive (false);
			}
			spawned = true;
		}
	}
}
