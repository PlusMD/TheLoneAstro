using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour {

    public float JetPackForce;
    public float startTime = 3.5f;
    public Rigidbody rb; 

    void Start()
    {
        //rb = GetComponent<Rigidbody>();

       
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F ))
        {
            startTime -= Time.deltaTime;
            rb.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * JetPackForce);
        }

        if (startTime <= 0.0f)
        {
            rb.velocity = Vector3.down * Time.smoothDeltaTime;
            startTime = 3.5f; 
        }
    }

}
