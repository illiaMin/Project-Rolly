using UnityEngine;
using UnityEngine.PlayerLoop;

public class MouseInputShot : MonoBehaviour
{
    private Turret _turret;
    bool _pressed = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _pressed = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _pressed = false;
        }

        if (_pressed)
        {
            _turret.TryShot();
        }
    }

    public void SetTurret(Turret turret)
    {
        _turret = turret;
    }
}
