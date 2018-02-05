using UnityEngine;

public class UIManager : MonoBehaviour 
{
	[SerializeField] GameObject helpObj , playerObj;

    void Start()
    {
        Time.timeScale = 0;        
    }

    public void OK() 
	{
		helpObj.SetActive(false);
		playerObj.SetActive(true);
        Time.timeScale = 1;
	}
}
