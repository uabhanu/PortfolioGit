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
		//Always create UI freshly to avoid complications
		helpButton.SetActive(true);
		helpObj.SetActive(false);
		quitButton.SetActive(true);
	}

	public void Help()
	{
		//Always create UI freshly to avoid complications
		helpButton.SetActive(false);
		helpObj.SetActive(true);
		quitButton.SetActive(false);
	}

	public void Quit()
	{
		//Always create UI freshly to avoid complications
		Application.Quit();
	}
}
