using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour 
{
	public GameObject helpButton , helpObj , quitButton;

	void Start() 
	{
	
	}

	public void Continue()
	{
		helpButton.SetActive(true);
		helpObj.SetActive(false);
		quitButton.SetActive(true);
	}

	public void Help()
	{
		helpButton.SetActive(false);
		helpObj.SetActive(true);
		quitButton.SetActive(false);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
