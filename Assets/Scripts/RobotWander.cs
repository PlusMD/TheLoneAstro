using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotWander : MonoBehaviour {

	public Transform[] points;
	int destPoint = 0;
	NavMeshAgent agent;
	public Animator animator;
	public Transform head;
	float waitTimer = 0f;
	public AudioSource audio;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		GotoNextPoint ();
	}
	
	// Update is called once per frame
	void GotoNextPoint () {
		if (points.Length == 0) {
			return;
		}

		destPoint = Random.Range (0, points.Length);

		agent.destination = points [destPoint].position;

		//destPoint = (destPoint + 1) % points.Length;
	}

	void Update(){
		if (!agent.pathPending && agent.remainingDistance < 0.5f) {
			if (waitTimer <= 0) {
				GotoNextPoint ();
				waitTimer = Random.Range (8, 15);
				animator.SetBool ("Walking", true);
			} else {
				waitTimer -= Time.deltaTime;
				animator.SetBool ("Walking", false);
			}
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Player") {
			agent.Stop ();
			animator.SetBool ("Walking", false);
			audio.Play ();
		}
	}

	void OnTriggerStay (Collider other) {
		if (other.tag == "Player") {
			head.LookAt (other.transform.position);
		}
	}

	void OnTriggerExit (Collider other) {
		if (other.tag == "Player") {
			agent.Resume ();
			animator.SetBool ("Walking", true);
			head.localEulerAngles = new Vector3 (0, -90, 0);
		}
	}
}
