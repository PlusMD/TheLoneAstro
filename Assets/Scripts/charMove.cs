using UnityEngine;
using System.Collections;

public class charMove : MonoBehaviour
{
	//BAse movement 
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;

	//Jetpack
	public float JetPackForce;
	public float startTime = 3.5f;
	public Rigidbody rb; 

    private Vector3 moveDirection = Vector3.zero;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

	void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			startTime -= Time.deltaTime;
			rb.AddForce(Vector3.up * JetPackForce);
			//rb.velocity = Vector3.up * JetPackForce; 
		}

		if (startTime <= 0.0f)
		{
			rb.velocity = Vector3.down * Time.smoothDeltaTime;
			startTime = 3.5f; 
		}
	}
}