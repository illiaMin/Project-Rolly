using UnityEngine;
using UnityEngine.UI;

public sealed class BMenuInput : MonoBehaviour
{
    private Text _text;

    public void Init(Text text)
    {
        _text = text;
    }

    public void Toggle()
    {
        GameObject target = _text.gameObject;
        target.SetActive(!target.activeSelf);
    }
}