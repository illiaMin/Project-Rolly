using UnityEngine;

public  class AuxiliaryModule : MonoBehaviour
{
    HP _hp;
    public ref HP GetHP()
    {
        return ref _hp;
    }

    public void SetHP(HP hp)
    {
        _hp = hp;
    }
}
