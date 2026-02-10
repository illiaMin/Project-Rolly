using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct HP
{
    public int Max;
    public int Current { get; private set; }

    public int Percent
    {
        get
        {
            if (Max <= 0) return 0;
            return Mathf.RoundToInt((float)Current / (float)Max * 100f);
        }
    }

    public HP(int max)
    {
        Max = Mathf.Max(max, 0);
        Current = Max;
    }

    public void SetCurrent(int current)
    {
        Current = Mathf.Clamp(current, 0, Max);
    }

    public void ApplyDamage(int damage)
    {
        int newValue = Current - Mathf.Max(damage, 0);
        Current = Mathf.Clamp(newValue, 0, Max);
    }
}