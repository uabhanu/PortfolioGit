using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class UIManager : MonoBehaviour 
{
	AICharacterControl m_enemyAI;

	[SerializeField] Transform m_playerTransform;

	public GameObject helpButton , helpObj , quitButton;

	void Start() 
	{
		m_enemyAI = FindObjectOfType<AICharacterControl>();
		Time.timeScale = 0;
	}

	public void Continue()
	{
		m_enemyAI.target = m_playerTransform;
		helpButton.SetActive(true);
		helpObj.SetActive(false);
		quitButton.SetActive(true);
		Time.timeScale = 1;
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
