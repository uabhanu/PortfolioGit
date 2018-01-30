using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
	private int causeDamage = 10;

	void OnCollisionEnter(Collision col)
	{
		var hit = col.gameObject;
		var health = hit.GetComponent<Health>();

		if(health != null)
		{
			health.TakeDamage(causeDamage);
		}

		Destroy(gameObject);
	}
}
