using System.Collections;
using UnityEngine;

public class ColourChanger : MonoBehaviour 
{
	public Material objMat;
	public Color objColour;

	void Start() 
	{
		
	}

	void Update() 
	{
		objColour = objMat.color;
	}
		
	void OnMouseDown()
	{
		if(objColour == Color.red)
		{
			Debug.Log("If red colour");
			objMat.color = Color.green;
		}

		if(objColour == Color.green)
		{
			Debug.Log("If green colour");
			objMat.color = Color.red;
		}
	}
}
