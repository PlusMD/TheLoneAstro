using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public ParticleSystem leftWheelFrontParticle;
	public ParticleSystem rightWheelFrontParticle;
	public ParticleSystem leftWheelRearParticle;
	public ParticleSystem rightWheelRearParticle;
    public bool motor;
    public bool steering;
}

public class RoverController : MonoBehaviour
{
    public List<AxleInfo> axleInfos;
    public float maxMotorTorque;
    public float maxSteeringAngle;
	public GameObject headLights;
	bool headlightsOn = false;
	public PlayerStats playerStats;

    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        if (collider.transform.childCount == 0)
        {
            return;
        }

        Transform visualWheel = collider.transform.GetChild(0);

        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);

        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }

    public void FixedUpdate()
    {
		float motor = maxMotorTorque * Input.GetAxis ("Vertical");
        float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

		if (playerStats.battery <= 0) {
			motor = 0;
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			headLights.SetActive (!headlightsOn);
			headlightsOn = !headlightsOn;
		}

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
			if (Input.GetAxis ("Vertical") >= 0.1) {
				var lwEM = axleInfo.leftWheelFrontParticle.emission;
				lwEM.enabled = true;
				var rwEM = axleInfo.rightWheelFrontParticle.emission;
				rwEM.enabled = true;
			}

			if (Input.GetAxis ("Vertical") <= -0.1) {
				var lwEM = axleInfo.leftWheelRearParticle.emission;
				lwEM.enabled = true;
				var rwEM = axleInfo.rightWheelRearParticle.emission;
				rwEM.enabled = true;
			}

			if (Input.GetAxis ("Vertical") > -0.1 && Input.GetAxis ("Vertical") < 0.1) {
				var lwEM = axleInfo.leftWheelRearParticle.emission;
				lwEM.enabled = false;
				var rwEM = axleInfo.rightWheelRearParticle.emission;
				rwEM.enabled = false;
				var lwEM2 = axleInfo.leftWheelFrontParticle.emission;
				lwEM2.enabled = false;
				var rwEM2 = axleInfo.rightWheelFrontParticle.emission;
				rwEM2.enabled = false;
			}
        }
    }
}