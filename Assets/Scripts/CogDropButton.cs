using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogDropButton : MonoBehaviour {

	public CogRecognition[] cogs;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public void DropAllCogs () {
		foreach(var cog in cogs){
			if (cog.hasCog == true) {
				cog.DropCogs ();
			}
		}
	}
}
