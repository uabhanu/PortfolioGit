using System.Collections;
using UnityEngine;

public class Resizer : MonoBehaviour 
{
	public Rotator rotationScript;
	public bool rotation;
	public bool increasable;
	public Material objMat;
	public Color objColour;
	public float scaleRate;

	void Start() 
	{
		
	}

	void Update() 
	{
		objColour = objMat.color;
		rotation = rotationScript.rotation;

		if(increasable)
		{
			IncreaseSize();
		}

		if(!increasable) 
		{
			DecreaseSize();
		}
	}

	void IncreaseSize()
	{
		if(transform.localScale.x <= 2.0f && transform.localScale.y <= 2.0f && transform.localScale.z <= 2.0f)
		{
			transform.localScale = new Vector3(transform.localScale.x + scaleRate , transform.localScale.y + scaleRate , transform.localScale.z + scaleRate);
		}
	}

	void DecreaseSize()
	{
		if(transform.localScale.x >= 1.1f && transform.localScale.y >= 1.0f && transform.localScale.z >= 1.0f)
		{
			transform.localScale = new Vector3(transform.localScale.x - scaleRate , transform.localScale.y - scaleRate , transform.localScale.z - scaleRate);
		}
	}

	void OnMouseDown()
	{
		if(objColour == Color.green && !rotation && !increasable)
		{
			increasable = true;
		}
		else
		{
			increasable = false;
		}
	}
}
