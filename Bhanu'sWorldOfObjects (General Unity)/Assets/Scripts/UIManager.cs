using UnityEngine;

public class UIManager : MonoBehaviour 
{
	[SerializeField] GameObject helpObj , playerObj;

	public void OK() 
	{
		helpObj.SetActive(false);
		playerObj.SetActive(true);
        Time.timeScale = 1;
	}
}
