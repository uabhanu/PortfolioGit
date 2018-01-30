﻿using SVGImporter;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChimpController : MonoBehaviour 
{
	private CircleCollider2D monkeynutCollider2D;
	private GameObject monkeyNut;
	private Rigidbody2D chimpBody2D;
	private SpriteRenderer monkeynutRenderer;
	private SVGRenderer ground01Renderer;
	private SVGRenderer ground02Renderer;
	private SVGRenderer ground03Renderer;

	public Animator chimpAnim;
	public AudioSource deathSound;
	public AudioSource jumpSound;
	public BananaSkin bananaSkinScript;
	public bool canJump;
	public bool chimpSlip;
	public bool grounded;
	public bool slide;
	public bool superMode;
	public float chimpSpeed;
	public float groundCheckRadius;
	public float jumpHeight;
	public float slideTime;
	public float slipTime;
	public float superTime;
	public GameObject[] chimpBlockers;
	public GameManager gameManagementScript;
	public Image bananaImage;
	public Image monkeynutImage;
	public Image dollarButtonImage;
	public Image trophyImage;
	public Ground groundScript;
	public LayerMask whatIsGround;
	public ScoreManager scoreManagementScript;
	public SVGImage pauseButtonImage;
	public Text bananaScore;
	public Text monkeynutScore;
	public Text trophiesScore;
	public Transform groundCheck;
	public UICheck uiCheckScript;

	void Start() 
	{
		chimpAnim.SetBool("DefaultSpeed" , true);
		chimpAnim.SetBool("MediumSpeed" , false);
		chimpAnim.SetBool("HighSpeed" , false);
		chimpBody2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		if(Time.timeScale == 0f)
		{
			return;
		}

		Run();

		if(!superMode) 
		{			
			chimpAnim.SetBool("Super" , false);
			//grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
		} 

		else if(superMode) 
		{
			chimpAnim.SetBool("Super" , true);
		}

		slide = chimpAnim.GetBool ("Slide");
		Run();
	}

	void Update() 
	{
		if(Time.timeScale == 0f)
		{
			return;
		}
			
		if(Input.GetMouseButton(0) && uiCheckScript.canJump)
		{
			Jump();
		}

		else if(Input.GetMouseButton(1))
		{
			Slide();
		}
	}

	IEnumerator ChimpSlip()
	{
		yield return new WaitForSeconds(slipTime);
		chimpSlip = false;
		chimpAnim.SetBool("DefaultSpeed" , true);
		chimpAnim.SetBool("MediumSpeed" , false);
		groundScript.speed -= 4f;
	}


	IEnumerator SlideTimer()
	{
		yield return new WaitForSeconds(slideTime);

		if(chimpAnim.GetBool("Slide"))
		{
			//Debug.Log("Slide Time"); Working
			chimpAnim.SetBool("Slide" , false);
		}
	}

	IEnumerator SuperChimpTimer()
	{
		yield return new WaitForSeconds(superTime);
		chimpBlockers[0].SetActive(false);
		chimpBody2D.gravityScale = 5f;
		superMode = false;
	}
		
	void Death()
	{
		//Debug.Log("Player Died"); Working
		deathSound.Play();
		gameManagementScript.RestartGame();
		bananaImage.enabled = false;
		bananaScore.enabled = false;
		dollarButtonImage.enabled = false;
		monkeynutImage.enabled = false;
		monkeynutScore.enabled = false;
		pauseButtonImage.enabled = false;
		trophyImage.enabled = false;
		trophiesScore.enabled = false;
	}

	void Dying()
	{

	}

	public void Jump()
	{
		if(grounded && canJump)
		{
			jumpSound.Play(); //Turned off for testing purposes but turn back on for final version
			chimpBody2D.velocity = new Vector2(chimpBody2D.velocity.x , jumpHeight);
			chimpBlockers[1].SetActive(false);
		}

		if(superMode)
		{
			chimpBody2D.velocity = new Vector2(chimpBody2D.velocity.x , jumpHeight*1.1f);
		}
	}

	void OnCollisionExit2D(Collision2D col2D)
	{
		if(col2D.gameObject.tag.Equals("Ground"))
		{
			grounded = false;
		}
	}

	void OnCollisionStay2D(Collision2D col2D)
	{
		if(col2D.gameObject.tag.Equals("Ground"))
		{
			grounded = true;
		}
	}

	void OnTriggerEnter2D(Collider2D col2D)
	{
		if(col2D.gameObject.tag.Equals("Death")) 
		{
			if(!superMode)
			{
				Debug.Log("Chimp Died");
				Death();
			}
		}

		if(col2D.gameObject.tag.Equals("Enemy") && !superMode) 
		{
			Debug.Log("Chimp Died");
			Death();
		}

		if(col2D.gameObject.tag.Equals("MN"))
		{
			SuperChimp();
		}

		if(col2D.gameObject.tag.Equals("Slip"))
		{
			//Debug.Log("Chimp Slip"); //Working
			chimpAnim.SetBool("DefaultSpeed" , false);
			chimpAnim.SetBool("MediumSpeed" , true);
			chimpSlip = true;
			groundScript.speed += 4f;
			StartCoroutine("ChimpSlip");
		}
	}

	void Run()
	{
		chimpAnim.SetBool("Grounded" , grounded);
		//chimpBody2D.velocity = new Vector2(chimpSpeed , chimpBody2D.velocity.y);
	}

	public void Slide()
	{
		if(!superMode && grounded)
		{
			//Debug.Log("Slide"); //Working
			chimpAnim.SetBool("Slide" , true);
			StartCoroutine("SlideTimer");
		}
	}

	void SuperChimp()
	{
		chimpBlockers[0].SetActive(true);
		chimpBlockers[1].SetActive(true);
		chimpBody2D.gravityScale = 2.5f;
		//monkeynutTaken++;
		//PlayerPrefs.SetInt("Monkeynut" , monkeynutTaken);
		superMode = true;
		StartCoroutine("SuperChimpTimer");
	}
}
