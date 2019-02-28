using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoverCargoHold : MonoBehaviour {

	GameObject mainCamera;
	public RoverControl roverControl;
	public GameObject hook;
	public bool grabbed = false;
	public LineRenderer towCable;
	GameObject hookedObject;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag("MainCamera");
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.E)) {
			//hook.GetComponent<SpringJoint>().connectedBody = null;
			towCable.SetPosition (0, hook.transform.position);
			towCable.SetPosition (1, hook.transform.position);
			Grab ();
		}

		if (Input.GetKeyUp (KeyCode.E) && grabbed == true) {
			Lock ();
		}

		if (grabbed == true && hookedObject != null) {
			towCable.SetPosition (0, hook.transform.position);
			towCable.SetPosition (1, hookedObject.transform.position);
			hookedObject.transform.position = towCable.transform.position;
		}
	}

	void Grab(){
		int x = Screen.width / 2;
		int y = Screen.height / 2;

		Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit)) {
			grabbed = true;
			if (hit.transform.tag == "Hook") {
				grabbed = true;
			}
		}
	}

	void Lock(){
		int x = Screen.width / 2;
		int y = Screen.height / 2;

		Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
		RaycastHit hit;
		if(Physics.Raycast(ray, out hit)) {
			if (hit.transform.tag == "Component") {
				//hook.GetComponent<SpringJoint>().connectedBody = hit.transform.GetComponent<Rigidbody>();
				hookedObject = hit.transform.gameObject;
				grabbed = false;
			}
		}
	}
}
