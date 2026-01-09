using System;
using System.Collections.Generic;
using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private float _leftHp = 100f;
    [SerializeField] private float _rightHp = 100f;
    
    [SerializeField] private float _BaseSpeed = 2f;
    [SerializeField] private float _turnSpeed = 2f;
    
    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //TakeInput1();
        TakeInput2();
    }
    
    void TakeInput2()
    {
        List<Vector2> allSpeeds = new List<Vector2>();
        List<float> allDirections = new List<float>();
        
        if (Input.GetKey(KeyCode.W))
        {
            CalculateSpeedAndDirectionW(out Vector2 speed, out float direction); 
            allSpeeds.Add(speed);
            allDirections.Add(direction);
        }
        if (Input.GetKey(KeyCode.S))
        {
            CalculateSpeedAndDirectionS(out Vector2 speed, out float direction); 
            allSpeeds.Add(speed);
            allDirections.Add(direction);
        }
        if (Input.GetKey(KeyCode.A))
        {
            CalculateSpeedAndDirectionA(out Vector2 speed, out float direction); 
            allDirections.Add(direction);
        }
        if (Input.GetKey(KeyCode.D))
        {
            CalculateSpeedAndDirectionD(out Vector2 speed, out float direction); 
            allDirections.Add(direction);
        }

        if (allDirections.Count > 0)
        {
            float resultDirection = 0;
            for (int i = 0; i < allDirections.Count; i++)
            {
                resultDirection += allDirections[i];
            }

            resultDirection /= allDirections.Count;

            allDirections.Clear();

            SetDirection(resultDirection);
        }
        else SetDirection(0f);
        
        if (allSpeeds.Count > 0)
        {
            var resultSpeed = Vector2.zero;

            for (int i = 0; i < allSpeeds.Count; i++)
            {
                resultSpeed += allSpeeds[i];
            }
            resultSpeed /= allSpeeds.Count;

            allSpeeds.Clear();
            
            SetVelocity(resultSpeed);
        }
        else SetVelocity(Vector2.zero);

    }
    void TakeInput1()
    {
        if (Input.GetKey(KeyCode.W))
        {
            CalculateSpeedAndDirectionW(out Vector2 speed, out float direction); 
            SetVelocityAndDirection(speed, direction);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            CalculateSpeedAndDirectionS(out Vector2 speed, out float direction); 
            SetVelocityAndDirection(speed, direction);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            CalculateSpeedAndDirectionA(out Vector2 speed, out float direction); 
            SetVelocityAndDirection(speed, direction);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            CalculateSpeedAndDirectionD(out Vector2 speed, out float direction); 
            SetVelocityAndDirection(speed, direction);
        }
        else
        {
            SetVelocityAndDirectionFalse();
        }
    }
    void SetVelocityAndDirection(Vector2 speed,  float direction)
    {
        _rb.linearVelocity = speed;
        _rb.angularVelocity =  direction;    
    }
    void SetDirection(float direction)
    {
        _rb.angularVelocity =  direction;    
    }
    void SetVelocity(Vector2 speed)
    {
        _rb.linearVelocity = speed;
    }
    void SetVelocityAndDirectionFalse()
    {
        _rb.linearVelocity = Vector2.zero;
        _rb.angularVelocity = 0f;
    }

    void CalculateLAndR(out float l, out float r)
    {
        l = _leftHp / 100;
        r = _rightHp / 100;
    }
    void CalculateSpeedAndDirectionW(out Vector2 speed, out float direction)
    {
        CalculateLAndR(out float l, out float r);
        speed = transform.up * (_BaseSpeed * (l + r));//* 0.5f);
        direction = _turnSpeed * (r - l);
    }
    void CalculateSpeedAndDirectionS(out Vector2 speed, out float direction)
    {
        CalculateLAndR(out float l, out float r);
        speed = -transform.up * (_BaseSpeed * (l + r));//* 0.5f);
        direction = _turnSpeed * (l - r);
    }
    void CalculateSpeedAndDirectionA(out Vector2 speed, out float direction)
    {
        CalculateLAndR(out float l, out float r);
        speed = Vector2.zero;
        direction = _turnSpeed * (l - r) + _turnSpeed;
    }
    void CalculateSpeedAndDirectionD(out Vector2 speed, out float direction)
    {
        CalculateLAndR(out float l, out float r);
        speed = Vector2.zero;
        direction = _turnSpeed * (r - l) - _turnSpeed;
    }
}
