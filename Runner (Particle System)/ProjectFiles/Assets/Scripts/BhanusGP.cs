//using GooglePlayGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BhanusGP : MonoBehaviour 
{
	public Image[] loginImages;

	void Awake()
	{
		//PlayGamesPlatform.DebugLogEnabled = true;
		//PlayGamesPlatform.Activate();
	}

	void Start()
	{
		Social.localUser.Authenticate((bool success) => 
		{
			if(success) 
			{
				Debug.Log ("Login Success");
				loginImages[0].enabled = false;
				loginImages[1].enabled = true;
				loginImages[2].enabled = true;
			}

			if(!success)
			{
				Debug.Log ("Login Failed");
				loginImages[0].enabled = true;
				loginImages[1].enabled = false;
				loginImages[2].enabled = false;
			}
		});
	}

	public void SignIn()
	{
		Social.localUser.Authenticate((bool success) => 
		{
			if(success) 
			{
				Debug.Log ("Login Success");
				loginImages[0].enabled = false;
				loginImages[1].enabled = true;
				loginImages[2].enabled = true;
			}

			if(!success)
			{
				Debug.Log ("Login Failed");
				loginImages[0].enabled = true;
				loginImages[1].enabled = false;
				loginImages[2].enabled = false;
			}
		});
	}

	public void SignOut()
	{
		//PlayGamesPlatform.Instance.SignOut(); //Or ((PlayGamesPlatform) Social.Active).SignOut();

		if(!Social.localUser.authenticated)
		{
			loginImages[0].enabled = true;
			loginImages[1].enabled = false;
			loginImages[2].enabled = false;
		}
	}
}
