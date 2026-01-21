using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed = 0f;
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

    public void SetInfo(SO_Projectile info, ProjectilesPool pool)
    {
        _lifeTime = info.LifeTime;
        _damage = info.Damage;
        
        _timeLeft = _lifeTime;
        _projectilesPool = pool;
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
}
