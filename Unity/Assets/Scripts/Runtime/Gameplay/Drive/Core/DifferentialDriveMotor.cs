using UnityEngine;
using UnityEngine.Serialization;

public class DifferentialDriveMotor : MonoBehaviour
{
    [SerializeField] private float _speedForward = 1.5f;
    [SerializeField] private float _speedBack = 1f;
    [SerializeField] private float _turnSpeed = 300f;

    private Vector2 _appliedVelocity =  Vector2.zero;
    private float _angularVelocity = 0;
    private Rigidbody2D _rb;

    public void SetSpeedForward(
        float speedForward) => _speedForward = speedForward;
    public void SetSpeedBack(
        float speedBack) => _speedBack = speedBack;
    public void SetTurnSpeed(
        float turnSpeed) => _turnSpeed = turnSpeed;
    public void SetRB(Rigidbody2D rb) => _rb = rb;

    public void Apply(DriveInput input, float leftFactor, float rightFactor)
    {
        Stop();
        
        float forwardPower = leftFactor + rightFactor;
        float diff = rightFactor - leftFactor;

        Vector2 velocity;
        if (input.Throttle < 0f)
        {
            velocity = _rb.transform.up * (_speedBack * forwardPower * input.Throttle);
        }
        else
        {
            velocity = _rb.transform.up * (_speedForward * forwardPower * input.Throttle);
        }
        float angular = (_turnSpeed * diff * input.Throttle) + (_turnSpeed * input.Turn);

        _appliedVelocity = velocity;
        _angularVelocity = angular;
        
        _rb.linearVelocity += _appliedVelocity;
        _rb.angularVelocity += _angularVelocity;
    }

    public void Stop()
    {
        _appliedVelocity = Vector2.zero;
        _angularVelocity = 0f;
    }
}