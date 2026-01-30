using UnityEngine;

public sealed class BMenu : MonoBehaviour
{
    private BMenuInput _input;

    public void Init(BMenuInput input)
    {
        _input = input;
    }

    public void Toggle()
    {
        _input.Toggle();
    }
}