using System.Collections;
using UnityEngine;

public class Doors : MonoBehaviour 
{
	Animator anim;

	void Start()
	{
		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag.Equals("Player"))
		{
			anim.SetBool("Open" , true);
			anim.SetBool("Close" , false);
			//DoorsState("Open");
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.gameObject.tag.Equals("Player"))
		{
			anim.SetBool("Open" , false);
			anim.SetBool("Close" , true);
			//DoorsState("Close");
		}
	}
}
