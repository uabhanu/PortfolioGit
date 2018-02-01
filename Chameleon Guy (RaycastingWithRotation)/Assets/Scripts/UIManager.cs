using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour 
{
	public GameObject helpButton , helpObj;

	void Start() 
	{
	
	}

	public void Continue()
	{
		helpButton.SetActive(true);
		helpObj.SetActive(false);
	}

	public void Help()
	{
		helpButton.SetActive(false);
		helpObj.SetActive(true);
	}

	public void Quit()
	{
		Application.Quit();
	}
}
