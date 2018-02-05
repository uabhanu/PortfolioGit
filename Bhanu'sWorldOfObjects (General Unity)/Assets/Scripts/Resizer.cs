using UnityEngine;

public class Resizer : MonoBehaviour 
{
	[SerializeField] bool m_increasable;
    float m_scaleRate = 0.01f;
	Material m_cubeMat;
    Rotator m_rotationScript;

	void Start() 
	{
        m_cubeMat = FindObjectOfType<ColourChanger>().GetComponent<MeshRenderer>().material;
		m_rotationScript = FindObjectOfType<Rotator>();
	}

	void Update() 
	{
		if(m_increasable)
		{
			IncreaseSize();
		}

		if(!m_increasable) 
		{
			DecreaseSize();
		}
	}

	void IncreaseSize()
	{
		if(transform.localScale.x <= 2.0f && transform.localScale.y <= 2.0f && transform.localScale.z <= 2.0f)
		{
			transform.localScale = new Vector3(transform.localScale.x + m_scaleRate , transform.localScale.y + m_scaleRate , transform.localScale.z + m_scaleRate);
		}
	}

	void DecreaseSize()
	{
		if(transform.localScale.x >= 1.1f && transform.localScale.y >= 1.0f && transform.localScale.z >= 1.0f)
		{
			transform.localScale = new Vector3(transform.localScale.x - m_scaleRate , transform.localScale.y - m_scaleRate , transform.localScale.z - m_scaleRate);
		}
	}

	void OnMouseDown()
	{
		if(m_cubeMat.color == Color.green && !m_rotationScript.m_rotation && !m_increasable)
		{
			m_increasable = true;
		}

		else if(m_cubeMat.color == Color.red || m_rotationScript.m_rotation || m_increasable)
		{
			m_increasable = false;
		}
	}
}
