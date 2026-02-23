using UnityEngine;
using UnityEngine.UI;

public class ID_CardUI : MonoBehaviour
{
    private Text _idCardText;
    public void SetIDCardText(Text idCardText) => _idCardText = idCardText;

    public void UpdateIDCardText(string idCardText)
    {
        _idCardText.text = idCardText;
    }
}
