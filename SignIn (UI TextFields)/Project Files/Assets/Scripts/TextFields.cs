using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFields : MonoBehaviour 
{
	private Color firstNameColour , lastNameColour , signInPasswordColour , signUpPasswordColour , signInUsernameColour , signUpUsernameColour;

	[SerializeField] private GameObject signInPasswordObj , signUpPasswordObj , signInQuitObj , signUpQuitObj , signInFormObj , signUpFormObj , signInFailedObj , signInSuccessObj , signUpSuccessObj , signInUsernameObj , signUpUsernameObj;
	[SerializeField] private Image firstNameImage , lastNameImage , signInPasswordImage , signUpPasswordImage , signInUsernameImage , signUpUsernameImage;
	[SerializeField] private InputField firstName , lastName , signInPassword , signUpPassword , signInUsername , signUpUsername;

	private string firstNameVariable , lastNameVariable , signInPasswordVariable , signUpPasswordVariable , signInUsernameVariable , signUpUsernameVariable;

	[SerializeField] private Text firstNameText;

    void Start()
    {
        firstNameColour = firstNameImage.color;
        lastNameColour = lastNameImage.color;
        OneSignal.Init("e2fd8d0d-7def-4522-9c43-697144d10458", "1007594176579", HandleNotification);
        signInPasswordColour = signInPasswordImage.color;
        signInUsernameColour = signInUsernameImage.color;
        signUpPasswordColour = signUpPasswordImage.color;
        signUpUsernameColour = signUpUsernameImage.color;

        StartCoroutine("TextFieldsColour");
    }

    void Update()
    {
        firstNameVariable = firstName.text;
        firstNameText.text = firstNameVariable;
        lastNameVariable = lastName.text;
        signInPasswordVariable = signInPassword.text;
        signInUsernameVariable = signInUsername.text;
        signUpPasswordVariable = signUpPassword.text;
        signUpUsernameVariable = signUpUsername.text;
    }

    IEnumerator TextFieldsColour()
	{
		yield return new WaitForSeconds(1f);

		if(firstNameVariable != "")
		{
			firstNameImage.color = firstNameColour;
		}

		if(lastNameVariable != "")
		{
			lastNameImage.color = lastNameColour;
		}

		if(signInPasswordVariable != "")
		{
			signInPasswordImage.color = signInPasswordColour;
		}

		if(signInUsernameVariable != "")
		{
			signInUsernameImage.color = signInUsernameColour;
		}

		if(signUpPasswordVariable != "")
		{
			signUpPasswordImage.color = signUpPasswordColour;
		}

		if(signUpUsernameVariable != "")
		{
			signUpUsernameImage.color = signUpUsernameColour;
		}

		StartCoroutine("TextFieldsColour");
	}
		
	public void Continue()
	{
		signInFormObj.SetActive(true);
		signUpFormObj.SetActive(false);
	}

	private static void HandleNotification(string message , Dictionary<string , object> additionalData , bool isActive) 
	{
		
	}

	//private void HandleShowResult(ShowResult result)
	//{
	//	switch (result)
	//	{
	//		case ShowResult.Finished:
	//			Debug.Log("The ad was successfully shown.");
	//			//
	//			// YOUR CODE TO REWARD THE GAMER
	//			// Give coins etc.
	//		break;

	//		case ShowResult.Skipped:
	//			Debug.Log("The ad was skipped before reaching the end.");
	//		break;

	//		case ShowResult.Failed:
	//			Debug.LogError("The ad failed to be shown.");
	//		break;
	//	}
	//}

	public void Quit()
	{
		Application.Quit();
	}

	public void SignIn()
	{
		if(signInUsernameVariable != "" && signInPasswordVariable != "")
		{
			if(signInUsername.text == signUpUsernameVariable && signInPassword.text == signUpPasswordVariable) 
			{
				signInPasswordObj.SetActive(false);
				signInUsernameObj.SetActive(false);
				signInQuitObj.SetActive(true);
				signInSuccessObj.SetActive(true);
			} 

			if(signInUsername.text != signUpUsernameVariable || signInPassword.text != signUpPasswordVariable) 
			{
				signInFailedObj.SetActive(true);
			}
		}
			
		if(signInPasswordVariable == "")
		{
			signInPasswordImage.color = Color.red;
		}

		if(signInUsernameVariable == "")
		{
			signInUsernameImage.color = Color.red;
		}
	}

	public void SignUp()
	{
		if(firstNameVariable != "" && lastNameVariable != "" && signUpPasswordVariable != "" && signUpUsernameVariable != "") 
		{
			signUpPasswordObj.SetActive(false);
			signUpQuitObj.SetActive(false);
			signUpSuccessObj.SetActive(true);
			signUpUsernameObj.SetActive(false);
		} 
			
		if(firstNameVariable == "")
		{
			firstNameImage.color = Color.red;
		}

		if(lastNameVariable == "")
		{
			lastNameImage.color = Color.red;
		}

		if(signUpPasswordVariable == "")
		{
			signUpPasswordImage.color = Color.red;
		}

		if(signUpUsernameVariable == "")
		{
			signUpUsernameImage.color = Color.red;
		}
	}

	public void TryAgain()
	{
		signInFailedObj.SetActive(false);
	}

	//public void UnityAds()
	//{
	//	if (Advertisement.IsReady("rewardedVideo"))
	//	{
	//		var options = new ShowOptions { resultCallback = HandleShowResult };
	//		Advertisement.Show("rewardedVideo" , options);
	//	}
	//}
}
