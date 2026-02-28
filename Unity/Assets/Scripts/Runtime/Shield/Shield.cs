using UnityEngine;

public class Shield : AuxiliaryModule
{
    [SerializeField] SpriteRenderer _spriteRenderer;
    public SpriteRenderer GetSpriteRenderer() => _spriteRenderer;
    

    public bool GetProtection()
    {
        return false;
    }
}
