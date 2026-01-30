using UnityEngine;

public class DifferentialDriveStats : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] private float _leftHp = 100f;
    [SerializeField, Range(0f, 100f)] private float _rightHp = 100f;

    public void SetHPs(int leftSide, int rightSide)
    {
        _leftHp = leftSide;
        _rightHp = rightSide;
    }
    public float LeftFactor
    {
        get { return Mathf.Clamp01(_leftHp / 100f); }
    }

    public float RightFactor
    {
        get { return Mathf.Clamp01(_rightHp / 100f); }
    }
}