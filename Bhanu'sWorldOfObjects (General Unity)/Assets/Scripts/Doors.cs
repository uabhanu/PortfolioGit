using UnityEngine;

public class Doors : MonoBehaviour 
{
	Animator m_anim;
    bool m_doorsOpen;

	void Start()
	{
		m_anim = GetComponent<Animator>();
        Time.timeScale = 0;
	}

    void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        
        if(Input.GetButtonDown("Action"))
        {
            m_anim.SetBool("Open" , !m_doorsOpen);
            m_anim.SetBool("Close" , m_doorsOpen);
            m_doorsOpen = !m_doorsOpen;
        }
    }
}
