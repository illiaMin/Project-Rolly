using UnityEngine;

public class PlayerDrive : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _inputSourceBehaviour;

    [SerializeField] private float _throttleMultiplier = 1f;
    [SerializeField] private float _turnMultiplier = 1f;

    private IDriveInputSource _inputSource;
    private DifferentialDriveMotor _motor;
    private DifferentialDriveStats _stats;

    private DriveInput _cachedInput;

    public void Init(
        DifferentialDriveMotor motor, DifferentialDriveStats stats)
    {
        _motor = motor;
        _stats = stats;
    }
    private void Awake()
    {
        _inputSource = _inputSourceBehaviour as IDriveInputSource;
    }

    private void Update()
    {
        if (_inputSource == null)
        {
            _cachedInput = new DriveInput(0f, 0f);
            return;
        }

        DriveInput rawInput = _inputSource.Read();

        _cachedInput = new DriveInput(
            rawInput.Throttle * _throttleMultiplier,
            rawInput.Turn * _turnMultiplier
        );
    }

    private void FixedUpdate()
    {
        if (_cachedInput.Throttle == 0f && _cachedInput.Turn == 0f)
        {
            _motor.Stop();
            return;
        }
        _motor.Apply(_cachedInput, _stats.LeftFactor, _stats.RightFactor);
    }
}