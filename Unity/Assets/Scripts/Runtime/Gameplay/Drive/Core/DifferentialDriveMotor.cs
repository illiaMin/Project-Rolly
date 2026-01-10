using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D))]
public class DifferentialDriveMotor : MonoBehaviour
{
    [SerializeField] private float _speedForward = 2f;
    [SerializeField] private float _speedBack = 2f;
    [SerializeField] private float _turnSpeed = 300f;

    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Apply(DriveInput input, float leftFactor, float rightFactor)
    {
        float forwardPower = leftFactor + rightFactor;
        float diff = rightFactor - leftFactor;

        Vector2 velocity;
        if (input.Throttle < 0f)
        {
            velocity = transform.up * (_speedBack * forwardPower * input.Throttle);
        }
        else
        {
            velocity = transform.up * (_speedForward * forwardPower * input.Throttle);
        }
        float angular = (_turnSpeed * diff * input.Throttle) + (_turnSpeed * input.Turn);

        _rb.linearVelocity = velocity;
        _rb.angularVelocity = angular;
    }

    public void Stop()
    {
        _rb.linearVelocity = Vector2.zero;
        _rb.angularVelocity = 0f;
    }
}