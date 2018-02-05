using UnityEngine;

public class ColourChanger : MonoBehaviour 
{
    Color objColour;
	Material objMat;

    void Start()
    {
        objMat = GetComponent<MeshRenderer>().material;    
    }

    void OnMouseDown()
	{
        objColour = objMat.color;

		if(objColour == Color.red)
		{
			Debug.Log("If red colour");
			objMat.color = Color.green;
		}

		if(objColour == Color.green)
		{
			Debug.Log("If green colour");
			objMat.color = Color.red;
		}
	}
}
