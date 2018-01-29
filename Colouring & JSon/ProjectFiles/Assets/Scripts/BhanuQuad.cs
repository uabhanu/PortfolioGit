using UnityEngine;
using System.Collections;

public class BhanuQuad : MonoBehaviour 
{
	MeshRenderer quadRenderer;

	void Start() 
	{
		quadRenderer = GetComponent<MeshRenderer>();
		quadRenderer.materials[1].color = Color.blue;
	}

	void Update() 
	{
	
	}
}
