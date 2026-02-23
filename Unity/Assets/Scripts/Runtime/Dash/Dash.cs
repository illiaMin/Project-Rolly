using UnityEngine;

public class Dash : AuxiliaryModule
{
    [SerializeField] SpriteRenderer _spriteRenderer;
    
    public SpriteRenderer GetSpriteRenderer() => _spriteRenderer;
    
    private float _powerOfDash;
    public void SetPowerOfDash(float powerOfDash) 
        => _powerOfDash = powerOfDash;
    
    private Rigidbody2D _rb;
    public void SetRigidBody(Rigidbody2D rb) 
        => _rb = rb;
    public void DoDash()
    {
        Vector2 dashDirection = _rb.linearVelocity;
        dashDirection *= _powerOfDash;
        _rb.AddForce(dashDirection, ForceMode2D.Impulse);
    }

    public void Toggle()
    {
        DoDash();
    }
}
