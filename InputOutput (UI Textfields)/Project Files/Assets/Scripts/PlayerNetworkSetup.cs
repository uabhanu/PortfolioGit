using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerNetworkSetup : NetworkBehaviour 
{
	public override void OnStartLocalPlayer()
	{
		GetComponent<Controller2D>().enabled = true;
		GetComponent<PlayerController>().enabled = true;
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}
}
