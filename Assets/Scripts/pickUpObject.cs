using UnityEngine;
using System.Collections;

public class pickUpObject : MonoBehaviour {

    public Transform player; 
    GameObject mainCamera;
	public bool carrying;
	public GameObject carriedObject;
	public float distance;
	public float smooth;

    bool playerInRange = false; 
    
	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	// Update is called once per frame
	void Update () {

        float dist = Vector3.Distance(gameObject.transform.position, player.position);

        if (dist <= 1.5f)
        {
            playerInRange = true; 
        } 
        else
        {
            playerInRange = false; 
        }


		if(carrying) {
			if (carriedObject == null) {
				resetObject ();
			}

			carry(carriedObject);
			checkDrop();
		} else {
			pickup();
		}
	}

	void rotateObject() {
		carriedObject.transform.Rotate(5,10,15);
	}

	void carry(GameObject o) {
		o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
		o.transform.rotation = Quaternion.identity;
	}

	void pickup() {
		if(playerInRange && Input.GetKeyDown (KeyCode.Q)) {
			int x = Screen.width / 2;
			int y = Screen.height / 2;

			Ray ray = mainCamera.GetComponent<Camera>().ScreenPointToRay(new Vector3(x,y));
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit)) {
				canPickUp p = hit.collider.GetComponent<canPickUp>();
				if(p != null) {
					carrying = true;
					carriedObject = p.gameObject;
					p.gameObject.GetComponent<Rigidbody>().useGravity = false;
				}
			}
		}
	}

	void checkDrop() {
		if(Input.GetKeyDown (KeyCode.Q)) {
			dropObject();
		}
	}

	public void dropObject() {
		carrying = false;
		carriedObject.GetComponent<Rigidbody> ().useGravity = true;
		carriedObject = null;
	}

	void resetObject(){
		carrying = false;
	}
}
