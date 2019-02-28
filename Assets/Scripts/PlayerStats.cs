using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public float O2 = 100f;
	float temp = 50f;
	public float battery = 100f;

	public float O2Drain = 0.5f;
	public float batteryDrain = 0.5f;
	public int O2Tanks;

	public Image O2UI;
	public Text O2Tracker;
	public Image tempUI;
	public Image batteryUI;

	public bool gameStarted = false;

	public GameObject mapUI;

	public RoverControl roverControl;
	public GameObject player;
	public GameObject camera;
	public GameObject vCam;
	public Animator deathUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gameStarted == true) {
			if (roverControl.entered == false) {
				O2 -= Time.deltaTime * O2Drain;
				if (battery < 100f) {
					battery += Time.deltaTime * batteryDrain;
				}
			}

			O2UI.fillAmount = O2 * 0.01f;
			O2Tracker.text = O2Tanks.ToString ();

			tempUI.fillAmount = temp * 0.01f;

			if (roverControl.entered == true && battery > 0) {
				battery -= Time.deltaTime * batteryDrain;
			}

			batteryUI.fillAmount = battery * 0.01f;

			if (O2 <= 0 && O2Tanks > 0) {
				O2 = 100f;
				O2Tanks -= 1;
			}

			if (Input.GetKeyDown (KeyCode.Tab)) {
				mapUI.SetActive (true);
			}

			if (Input.GetKeyUp (KeyCode.Tab)) {
				mapUI.SetActive (false);
			}
		}

		if (O2 <= 0 && O2Tanks == 0) {
			Die();
		}
	}

	public void Die(){
		player.SetActive(false);
		vCam.transform.position = camera.transform.position;
		vCam.transform.rotation = camera.transform.rotation;
		deathUI.SetBool ("Die", true);
	}

	public void StartGame (){
		gameStarted = true;
	}
}
