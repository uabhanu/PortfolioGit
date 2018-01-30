﻿using System.Collections;
using UnityEngine;

public class Nut : MonoBehaviour 
{
	private bool clickSafeZone;
	private Rigidbody2D nutBody2D;
	private ScoreManager scoreManagementScript;

	void Start() 
	{
		nutBody2D = GetComponent<Rigidbody2D>();
		scoreManagementScript = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
	}

	void Update() 
	{
		nutBody2D.velocity = new Vector2(nutBody2D.velocity.x , -1f);
	}

	void OnMouseDown()
	{
		if(clickSafeZone)
		{
			if(scoreManagementScript.bananaScoreValue > 0)
			{
				scoreManagementScript.bananaScoreValue--;
			}

			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col2D)
	{
		if(col2D.gameObject.tag.Equals("Cleaner"))
		{
			Destroy(gameObject);
		}

		if(col2D.gameObject.tag.Equals("CSZ"))
		{
			clickSafeZone = true;
		}
	}

	void OnTriggerExit2D(Collider2D col2D)
	{
		if(col2D.gameObject.tag.Equals("CSZ"))
		{
			clickSafeZone = false;
		}
	}
}
