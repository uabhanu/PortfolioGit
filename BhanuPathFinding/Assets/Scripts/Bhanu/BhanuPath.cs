using UnityEngine;

public class BhanuPath : MonoBehaviour 
{
    [SerializeField] bool _isFollowingPlayer , _obstacleDetected;
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

        _isFollowingPlayer = !_obstacleDetected;
        DetectObstacle();
        FollowPlayer();
        RotateToEvade();
    }

    void DetectObstacle()
    {
        Debug.DrawRay(transform.position , transform.TransformDirection(Vector3.forward) * _lineOfSight , Color.red);
        _ray = new Ray(transform.position , transform.TransformDirection(Vector3.forward) * _lineOfSight);

        if(Physics.Raycast(_ray , out _hit , _lineOfSight))
        {
            if(_hit.collider.gameObject.layer == 11)
            {
                _obstacleDetected = true;
            }
        }
        else
        {
            _obstacleDetected = false;
        }
    }

    void RotateToEvade()
    {
        if(_obstacleDetected)
        {
            //TODO For some reason, this is working on it's own but once movement logic exists, this doesn't work, figure it out
            transform.Rotate(Vector3.up * 15f * Time.deltaTime);
        }
    }

    void FollowPlayer()
    {
        transform.LookAt(_playerToLookAt.position);

        if((transform.position - _playerToLookAt.position).magnitude > _offset && _isFollowingPlayer)
        {
            transform.Translate(0f , 0f , _moveSpeed * Time.deltaTime);
        }
    }
}
