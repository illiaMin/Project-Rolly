using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float _speed = 0f;
    private float _lifeTime = 0f;
    private SO_Damage _damage;
    private float _timeLeft = 0f;

    private Rigidbody2D _rigidbody2D;
    
    ProjectilesPool _projectilesPool;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void SetInfo(SO_Projectile info, ProjectilesPool pool)
    {
        _speed =  info.Speed;
        _lifeTime = info.LifeTime;
        _damage = info.Damage;
        
        _timeLeft = _lifeTime;
        _projectilesPool = pool;
    }
    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = transform.up * _speed;
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
