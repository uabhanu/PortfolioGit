using UnityEngine;

public class BhanuPath : MonoBehaviour 
{
    Ray _ray;
    RaycastHit _hit;

    [SerializeField] float _lineOfSight , _moveSpeed , _offset;
    [SerializeField] Transform _playerToLookAt;

	void Start() 
    {
		
	}
	
	void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }

        AvoidObstacles();
        FollowPlayer();
    }

    void AvoidObstacles()
    {
        Debug.DrawRay(transform.position , transform.TransformDirection(Vector3.forward) * _lineOfSight , Color.red);
        _ray = new Ray(transform.position , transform.TransformDirection(Vector3.forward) * _lineOfSight);

        if(Physics.Raycast(_ray , out _hit , _lineOfSight))
        {
            if(_hit.collider.gameObject.layer == 11)
            {
                //TODO Evade Logic here, Look into Slerp
            }
        }
    }

    void FollowPlayer()
    {
        transform.LookAt(_playerToLookAt.position);

        if((transform.position - _playerToLookAt.position).magnitude > _offset)
        {
            transform.Translate(0f , 0f , _moveSpeed * Time.deltaTime);
        }
    }
}
