using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private bool _normalFollowingByPlayer = true; 
    void LateUpdate()
    {
        if (_normalFollowingByPlayer)
        {
            var newPosition = 
                _target.position + new Vector3(0,0,transform.position.z);
            
            transform.position = newPosition;
        }
    }
}
