using System.Collections;
using UnityEngine;

public class UICheck : MonoBehaviour 
{
	public bool canJump;

	void Start() 
	{
	
	}

	void Update() 
	{
	
	}

	void OnMouseExit()
	{
		canJump = false;
	}

	void OnMouseOver()
	{
		canJump = true;
	} 
}
