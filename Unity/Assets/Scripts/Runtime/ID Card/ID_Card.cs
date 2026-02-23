using UnityEngine;

public class ID_Card : MonoBehaviour
{
    [SerializeField] private ID_CardUI _idCardUI;
    public ID_CardUI GetIDCardUI() => _idCardUI;
}
