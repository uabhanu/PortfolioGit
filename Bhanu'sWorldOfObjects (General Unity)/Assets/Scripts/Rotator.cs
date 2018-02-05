using UnityEngine;

public class Rotator : MonoBehaviour 
{
	float m_spinSpeed = 50f;

    public bool m_shouldRotate;

    void Update()
    {
        if(m_shouldRotate)
        {
            Rotate();
        }

        else if(!m_shouldRotate || Time.timeScale == 0)
        {
            return;
        }
    }

    void Rotate()
	{
		transform.Rotate(0 , m_spinSpeed * Time.deltaTime , 0);
	}

	void OnMouseDown()
	{
		m_shouldRotate = !m_shouldRotate;
	}
}
