using UnityEngine;

public class BhanuPath : MonoBehaviour 
{
    [SerializeField] float m_moveSpeed , m_offset;
    [SerializeField] Transform m_playerToLookAt;

	void Start() 
    {
		
	}
	
	void Update() 
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        transform.LookAt(m_playerToLookAt.position);

        if((transform.position - m_playerToLookAt.position).magnitude > m_offset)
        {
            transform.Translate(0f , 0f , m_moveSpeed * Time.deltaTime);
        }
    }
}
