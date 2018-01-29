using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BhanuSliders : MonoBehaviour 
{
	[SerializeField] float offset01 , offset02;
	[SerializeField] Slider slider01 , slider02;

	void FixedUpdate()
	{
		slider01.value += offset01 * Time.deltaTime;

		if(slider01.value >= 0.99f)
		{
			slider02.value += offset02 * Time.deltaTime;
		}
	}
}
