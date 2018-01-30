using UnityEngine;
using UnityEngine.Networking;


public class PlayerController : NetworkBehaviour
{
	[SerializeField]
	private GameObject PF_Bullet;

	[SerializeField]
	private Transform bulletSpawnLocation;

	void Update()
	{
		if(!isLocalPlayer)
		{
			GetComponent<MeshRenderer>().material.color = Color.red;
			return;
		}

		if(Input.GetKeyDown(KeyCode.Space))
		{
			CmdFire();
		}

		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);
	}

	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}

	[Command]
	void CmdFire()
	{
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate (PF_Bullet , bulletSpawnLocation.position , bulletSpawnLocation.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
		NetworkServer.Spawn(PF_Bullet);

		// Destroy the bullet after 2 seconds
		Destroy(bullet , 2.0f);
	}
}