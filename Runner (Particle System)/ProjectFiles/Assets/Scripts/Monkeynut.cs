using System.Collections;
using UnityEngine;

public class Monkeynut : MonoBehaviour 
{
	private CircleCollider2D monkeynutCollider2D;
	private ChimpController chimpControlScript;
	private float maxY;
	private float minY;
	private float startPos;
	private int direction = 1;
	private Rigidbody2D nutBody2D;
	private ScoreManager scoreManagementScript;
	private SpriteRenderer monkeynutRenderer;

	public Ground groundScript;


	void Start() 
	{
		monkeynutCollider2D = GetComponent<CircleCollider2D>();
		monkeynutRenderer = GetComponent<SpriteRenderer>();
		nutBody2D = GetComponent<Rigidbody2D>();
		chimpControlScript = GameObject.Find("Chimp").GetComponent<ChimpController>();
		maxY = this.transform.position.y + 0.5f;
		minY = maxY - 1.0f;
		scoreManagementScript = FindObjectOfType<ScoreManager>();
		StartCoroutine("SoundObjectTimer");
		startPos = transform.position.x;
	}

	void FixedUpdate()
	{
		if(Time.timeScale == 0f)
		{
			return;
		}
			
		nutBody2D.velocity = new Vector2(-groundScript.speed , nutBody2D.velocity.y);

		if(transform.position.x < -8.5f)
		{
			transform.position = new Vector3(startPos , 2f , 0f);
		}
	}

	void Update() 
	{
		if(Time.timeScale == 0f)
		{
			return;
		}

		this.transform.position = new Vector2(this.transform.position.x , this.transform.position.y + (direction * 0.05f));

		if(this.transform.position.y > maxY) 
		{
			direction = -1;
		}
			
		if(this.transform.position.y < minY) 
		{
			direction = 1;
		}

		if(chimpControlScript.superMode)
		{
			monkeynutCollider2D.enabled = false;
			monkeynutRenderer.enabled = false;
		}

		if(!chimpControlScript.superMode)
		{
			monkeynutCollider2D.enabled = true; //IAP will make monkeynutTaken false again
			monkeynutRenderer.enabled = true;
		}
	}
		
	IEnumerator SoundObjectTimer()
	{
		yield return new WaitForSeconds(0.4f);
		StartCoroutine("SoundObjectTimer");
	}
		
	void OnTriggerEnter2D(Collider2D col2D)
	{
		if(col2D.gameObject.tag.Equals("Player"))
		{
			monkeynutCollider2D.enabled = false;
			monkeynutRenderer.enabled = false;
			scoreManagementScript.monkeynutScoreValue++;
		}
	}
}
