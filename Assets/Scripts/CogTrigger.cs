using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogTrigger : MonoBehaviour {

	int correctCogs = 0;
	public Animator objectToAnimate;

	// Update is called once per frame
	void Update () {
		if (correctCogs == 3) {
			objectToAnimate.SetTrigger ("Open");
		}
	}

	public void CogCheck () {
		correctCogs += 1;
	}
}
