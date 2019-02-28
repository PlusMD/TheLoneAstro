using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour {

    Vector2 mouseLookAt;
    Vector2 smooth;
    public float sens = 5.0f;
    public float smoothing = 0.5f;

    GameObject character; 

	// Use this for initialization
	void Start () {
        character = this.transform.parent.gameObject; 
	}
	
	// Update is called once per frame
	void Update () {
        var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        md = Vector2.Scale(md, new Vector2(sens * smoothing, sens * smoothing));
        smooth.x = Mathf.Lerp(smooth.x, md.x, 1f/ smoothing) ;
        smooth.y = Mathf.Lerp(smooth.y, md.y, 1f / smoothing);
        mouseLookAt += smooth;
        mouseLookAt.y = Mathf.Clamp(mouseLookAt.y, -90f, 90f); 

        transform.localRotation = Quaternion.AngleAxis(-mouseLookAt.y, Vector3.right);
        character.transform.localRotation = Quaternion.AngleAxis(mouseLookAt.x, character.transform.up); 

    }
}
