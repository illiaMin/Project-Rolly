using UnityEngine;

public class MiniMap : AuxiliaryModule
{
    [SerializeField] SpriteRenderer _spriteRenderer;
    public SpriteRenderer GetSpriteRenderer() => _spriteRenderer;
    
}
