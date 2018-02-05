using UnityEngine;

public class ColourChanger : MonoBehaviour 
{
	Material m_cubeMaterial;

    void Start()
    {
        m_cubeMaterial = GetComponent<MeshRenderer>().material;    
    }

    void OnMouseDown()
	{
		if(m_cubeMaterial.color == Color.red)
		{
			Debug.Log("If red colour");
			m_cubeMaterial.color = Color.green;
		}

		else if(m_cubeMaterial.color == Color.green)
		{
			Debug.Log("If green colour");
			m_cubeMaterial.color = Color.red;
		}
	}
}
