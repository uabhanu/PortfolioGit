using UnityEngine;

public class ColourChanger : MonoBehaviour 
{
	Material m_material;

    void Start()
    {
        m_material = GetComponent<MeshRenderer>().material;    
    }

    void OnMouseDown()
	{
		if(m_material.color == Color.red)
		{
			Debug.Log("If red colour");
			m_material.color = Color.green;
		}

		else if(m_material.color == Color.green)
		{
			Debug.Log("If green colour");
			m_material.color = Color.red;
		}
	}
}
