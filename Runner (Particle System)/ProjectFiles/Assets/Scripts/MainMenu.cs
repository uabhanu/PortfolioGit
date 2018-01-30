using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	public GameObject exit , helpButton , helpObj;
	public GameObject loginButtonsObj;
	public GameObject playButton;
	public GameObject quitButton;
	public GameObject quitImage;
	public string gameLevel;

	public void Continue()
	{
		helpObj.SetActive(false);
	}

	public void Help()
	{
		helpObj.SetActive(true);
	}

	public void No()
	{
		exit.SetActive(false);
		quitImage.SetActive(false);

		helpButton.SetActive(true);
		//loginButtonsObj.SetActive(true);
		playButton.SetActive(true);
		quitButton.SetActive(true);
	}

	public void Play() 
	{
		SceneManager.LoadScene(gameLevel);
	}

	public void Quit() 
	{
		exit.SetActive(true);
		quitImage.SetActive(true);

		helpButton.SetActive(false);
		//loginButtonsObj.SetActive(false);
		playButton.SetActive(false);
		quitButton.SetActive(false);
	}
		
	public void Yes()
	{
		Application.Quit();
	}
}
