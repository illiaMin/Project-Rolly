using UnityEngine;

public sealed class Wheels : MonoBehaviour, IDamageable
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
        int sideMaxHp = info.HP.Max;
        _leftHp = new HP(sideMaxHp);
        _rightHp = new HP(sideMaxHp);

        playerDrive.Init(_motor, _stats);

        _motor.SetSpeedForward(info.SpeedForward);
        _motor.SetSpeedBack(info.SpeedBackward);
        _motor.SetTurnSpeed(info.TurnSpeed);

        Rigidbody2D rigidbody2D = body.GetComponent<Rigidbody2D>();
        _motor.SetRB(rigidbody2D);

        _stats.SetHPs(_leftHp.Current, _rightHp.Current);
    }

    public void TakeDmg(SO_Damage damage)
    {
        
    }
}