using UnityEngine;

public struct DriveInput
{
    public float Throttle; // -1..1 
    public float Turn;     // -1..1 

    public DriveInput(float throttle, float turn)
    {
        Throttle = Mathf.Clamp(throttle, -1f, 1f);
        Turn = Mathf.Clamp(turn, -1f, 1f);
    }
}