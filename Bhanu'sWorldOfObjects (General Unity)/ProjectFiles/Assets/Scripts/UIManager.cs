using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour 
{
	[SerializeField]
	private GameObject helpObj , playerObj;

	public void OK() 
	{
		helpObj.SetActive(false);
		playerObj.SetActive(true);
	}
}
