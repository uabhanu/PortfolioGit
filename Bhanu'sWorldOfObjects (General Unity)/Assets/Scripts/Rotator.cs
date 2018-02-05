using UnityEngine;

public class Rotator : MonoBehaviour 
{
	float m_spinSpeed;

    public bool m_rotation;

    void Update()
    {
        if(m_rotation)
        {
            Rotation();
        }

        if(!m_rotation)
        {
            StopRotation();
        }
    }

    void Rotation()
	{
		m_spinSpeed = 50f;
		transform.Rotate(0 , m_spinSpeed * Time.deltaTime , 0);
	}

	void StopRotation()
	{
		m_spinSpeed = 0f;
		transform.Rotate(0 , m_spinSpeed * Time.deltaTime , 0);
	}

	void OnMouseDown()
	{
		if(m_spinSpeed > 0f)
		{
			m_rotation = false;
		}

		if(m_spinSpeed == 0f) 
		{
			m_rotation = true;
		}
	}
}
