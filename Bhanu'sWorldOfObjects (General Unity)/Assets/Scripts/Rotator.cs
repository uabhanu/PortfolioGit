using System.Collections;
using UnityEngine;

public class Rotator : MonoBehaviour 
{
	public float spinSpeed;
	public bool rotation;

	void Start () 
	{
	
	}

	void Update () 
	{
		if(rotation)
		{
			Rotation();
		}

		if(!rotation)
		{
			StopRotation();
		}
	}

	void Rotation()
	{
		spinSpeed = 50f;
		transform.Rotate(0 , spinSpeed * Time.deltaTime , 0);
	}

	void StopRotation()
	{
		spinSpeed = 0f;
		transform.Rotate(0 , spinSpeed * Time.deltaTime , 0);
	}

	void OnMouseDown()
	{
		if(spinSpeed > 0f)
		{
			rotation = false;
		}

		if(spinSpeed == 0f) 
		{
			rotation = true;
		}
	}
}
