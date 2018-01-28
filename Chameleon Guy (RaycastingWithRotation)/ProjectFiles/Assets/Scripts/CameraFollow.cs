using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
	private Rigidbody cameraBody , playerBody;

	void Start() 
	{
		cameraBody = GetComponent<Rigidbody>();
		playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
	}

	void FixedUpdate() 
	{
		cameraBody.velocity = new Vector3(playerBody.velocity.x , 0f , 0f);
	}
}
