using UnityEngine;

public sealed class Wheels : MonoBehaviour
{
    [SerializeField] private DifferentialDriveMotor _motor;
    [SerializeField] private DifferentialDriveStats _stats;
    
    [SerializeField] private SpriteRenderer _spriteRendererLeftSide;
    [SerializeField] private SpriteRenderer _spriteRendererRightSide;
    
    private HP _leftHp;
    private HP _rightHp;

    public SpriteRenderer GetLeftSide() => _spriteRendererLeftSide;
    public SpriteRenderer GetRightSide() => _spriteRendererRightSide;
    public void Init(SO_Wheels info, Transform body, PlayerDrive playerDrive)
    {
        playerDrive.Init(_motor, _stats);

        _motor.SetSpeedForward(info.SpeedForward);
        _motor.SetSpeedBack(info.SpeedBackward);
        _motor.SetTurnSpeed(info.TurnSpeed);

        Rigidbody2D rigidbody2D = body.GetComponent<Rigidbody2D>();
        _motor.SetRB(rigidbody2D);

        _stats.SetHPs(_leftHp.Current, _rightHp.Current);
    }
    
    public ref HP GetLeftHP()
    {
        return ref _leftHp;
    }
    public ref HP GetRightHP()
    {
        return ref _rightHp;
    }

    public void SetLeftHP(HP newHP)
    {
        _leftHp = newHP;
    }

    public void SetRightHP(HP newHP)
    {
        _rightHp = newHP;
    }
}