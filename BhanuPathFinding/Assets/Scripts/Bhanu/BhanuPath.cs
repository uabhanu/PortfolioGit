using UnityEngine;

public class BhanuPath : MonoBehaviour 
{
    [SerializeField] float m_moveSpeed , m_stoppingDistance;
    [SerializeField] GameObject m_playerToChase;

	void Start() 
    {
		
	}
	
	void Update() 
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        
        //TODO Chase Player Logic here, refer Bookmark
	}
}
