using System.Collections;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour 
{
	private Color playerDefaultColour;
	private float maxDistance;
	[SerializeField]
	private int lineOfSight;
	private SkinnedMeshRenderer playerSkinnedMesh;
	private RaycastHit hit;
	private Ray ray;

	void Start() 
	{
		playerSkinnedMesh = GameObject.Find("EthanBody").GetComponent<SkinnedMeshRenderer>();
		playerDefaultColour = playerSkinnedMesh.material.color;
	}

	void Update() 
	{
		BhanuRaycast();
	}

	void BhanuRaycast()
	{
		ray = new Ray(transform.position + Vector3.up , transform.TransformDirection(Vector3.forward));
		Debug.DrawRay(transform.position + Vector3.up , transform.TransformDirection(Vector3.forward) * lineOfSight , Color.yellow);

		if(Physics.Raycast(ray , out hit , lineOfSight))
		{
			if(hit.collider.tag.Equals("RSphere")) 
			{
				playerSkinnedMesh.material.color = Color.red;
			} 

			if(hit.collider.tag.Equals("GSphere")) 
			{
				playerSkinnedMesh.material.color = Color.green;
			} 

			if(hit.collider.tag.Equals("BSphere")) 
			{
				playerSkinnedMesh.material.color = Color.blue;
			} 

			if(hit.collider.tag.Equals("Env"))
			{
				playerSkinnedMesh.material.color = playerDefaultColour;
			}
		}
	}
}
