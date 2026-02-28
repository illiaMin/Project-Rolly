using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Collider2D _collider2D;
    private Collider2D _shooter;
    private float _lifeTime = 0f;
    private SO_Damage _damage;
    private float _timeLeft = 0f;

    ProjectilesPool _projectilesPool;
    
    private Rigidbody2D _rigidbody2D;
    public Rigidbody2D GetRigidbody2D() => _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetInfo(SO_Projectile info, ProjectilesPool pool, Collider2D shooter)
    {
        _lifeTime = info.LifeTime;
        _damage = info.Damage;
        
        _timeLeft = _lifeTime;
        _projectilesPool = pool;
        _shooter = shooter;
        
        Physics2D.IgnoreCollision(_collider2D, shooter, true);
    }
    private void FixedUpdate()
    {
        _timeLeft -= Time.fixedDeltaTime;

        if (_timeLeft <= 0)
        {
            _projectilesPool.Return(this);
        }
    }
    
    public void ResetState()
    {
        _timeLeft = 0f;

        if (_rigidbody2D != null)
        {
            _rigidbody2D.linearVelocity = Vector2.zero;
            _rigidbody2D.angularVelocity = 0f;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.transform.parent.TryGetComponent<HPOwner>(out HPOwner owner))
        {
            owner.ReceiveDmg(_damage);
            Physics2D.IgnoreCollision(_collider2D, _shooter, false);
            _projectilesPool.Return(this);
        }
    }
}
