using System.Collections;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextFields : MonoBehaviour 
{
	[SerializeField]
	private Color firstNameColour, lastNameColour;

	[SerializeField]
	private GameObject backgroundObj , formObj , outPutObj;

	[SerializeField]
	private Image firstNameImage , lastNameImage;

	[SerializeField]
	private InputField firstName , lastName;
	private string firstNameVariable , lastNameVariable;

	[SerializeField]
	private Text firstNameText , lastNameText , outputText;

	void Start() 
	{
		firstNameColour = firstNameImage.color;
		lastNameColour = lastNameImage.color;

		StartCoroutine("TextFieldColour");
	}

	void Update() 
	{
		firstNameVariable = firstName.text;
		lastNameVariable = lastName.text;
	}

	IEnumerator TextFieldColour()
	{
		yield return new WaitForSeconds(1f);

		if(firstNameText.text != "")
		{
			firstNameImage.color = firstNameColour;
		}

		if(lastNameText.text != "")
		{
			lastNameImage.color = lastNameColour;
		}

		StartCoroutine("TextFieldColour");
	}

	public void Back()
	{
		SceneManager.LoadScene(sceneBuildIndex:0);
	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Submit()
	{
		if(firstNameText.text != "" & lastNameText.text != "")
		{
			backgroundObj.SetActive(false);
			formObj.SetActive(false);
			outPutObj.SetActive(true);
			outputText.text = firstNameVariable + " " + lastNameVariable;
		}

		if(firstNameText.text == "")
		{
			Debug.Log("Firstname Null");
			firstNameImage.color = Color.red;
		}

		if(lastNameText.text == "")
		{
			lastNameImage.color = Color.red;
		}
	}
}
