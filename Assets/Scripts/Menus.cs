using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour {

	public GameObject pauseMenu;
	public bool menuOn = false;

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			menuOn = !menuOn;
			pauseMenu.SetActive (menuOn);
		}
	}

	public void Continue(){
		menuOn = false;
	}

	public void Restart(){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void Quit(){
		Application.Quit ();
	}
}
