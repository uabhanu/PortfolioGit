using System.Collections;
using UnityEngine;

public class SphereRaycast : MonoBehaviour 
{
	private Color sphereDefaultColour;
	private float maxDistance;
	[SerializeField]
	private int lineOfSight;
	private MeshRenderer sphereMesh;
	private SkinnedMeshRenderer playerSkinnedMesh;
	private RaycastHit hit;
	private Ray ray;

	void Start() 
	{
		playerSkinnedMesh = GameObject.Find("EthanBody").GetComponent<SkinnedMeshRenderer>();
		sphereMesh = GetComponent<MeshRenderer>();
		sphereDefaultColour = sphereMesh.material.color;
	}

	void Update() 
	{
		BhanuRaycast();
	}

	void BhanuRaycast()
	{
		ray = new Ray(transform.position , transform.TransformDirection(Vector3.back));
		Debug.DrawRay(transform.position , transform.TransformDirection(Vector3.back) * lineOfSight , Color.green);

		if(Physics.Raycast(ray , out hit , lineOfSight))
		{
			if(hit.collider.tag.Equals("Player")) 
			{
				sphereMesh.material.color = playerSkinnedMesh.material.color;
			} 

			if(hit.collider.tag.Equals("Env"))
			{
				sphereMesh.material.color = sphereDefaultColour;
			}
		}
	}
}
