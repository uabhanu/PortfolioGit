using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFields : MonoBehaviour 
{
	Color firstNameColour , lastNameColour , signInPasswordColour , signUpPasswordColour , signInUsernameColour , signUpUsernameColour;
    string firstNameVariable , lastNameVariable , signInPasswordVariable , signUpPasswordVariable , signInUsernameVariable , signUpUsernameVariable;

    [SerializeField] GameObject m_signInFailedObj , m_signInFormObj , m_signInSuccessObj , m_signUpFormObj , m_signUpSuccessObj;
	[SerializeField] Image firstNameImage , lastNameImage , signInPasswordImage , signUpPasswordImage , signInUsernameImage , signUpUsernameImage;
	[SerializeField] InputField firstName , lastName , signInPassword , signUpPassword , signInUsername , signUpUsername;
	[SerializeField] Text firstNameText;

    void Start()
    {
        //OneSignal.Init("e2fd8d0d-7def-4522-9c43-697144d10458", "1007594176579", HandleNotification);
        //StartCoroutine("TextFieldsColour");
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
		m_signInFormObj.SetActive(true);
		m_signUpFormObj.SetActive(false);
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
				m_signInSuccessObj.SetActive(true);
			} 

			if(signInUsername.text != signUpUsernameVariable || signInPassword.text != signUpPasswordVariable) 
			{
				m_signInFailedObj.SetActive(true);
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
			m_signUpFormObj.SetActive(false);
            m_signUpSuccessObj.SetActive(true);
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
		m_signInFailedObj.SetActive(false);
        m_signInFormObj.SetActive(true);
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
