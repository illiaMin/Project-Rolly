using UnityEngine;

public class KeyboardDriveInputSource : MonoBehaviour, IDriveInputSource
{
    public DriveInput Read()
    {
        float throttle = 0f;
        if (Input.GetKey(KeyCode.W)) throttle += 1f;
        if (Input.GetKey(KeyCode.S)) throttle -= 1f;

        float turn = 0f;
        if (Input.GetKey(KeyCode.D)) turn -= 1f;
        if (Input.GetKey(KeyCode.A)) turn += 1f;

        return new DriveInput(throttle, turn);
    }
}