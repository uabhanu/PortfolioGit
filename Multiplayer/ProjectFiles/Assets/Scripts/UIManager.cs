using System.Collections;
using UnityEngine;

public class UIManager : MonoBehaviour 
{
	[SerializeField]
	private GameObject helpObj , networkObjs;

	void Start() 
	{
		
	}

	public void OK() 
	{
		helpObj.SetActive(false);
		networkObjs.SetActive(true);
	}
}
