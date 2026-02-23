using UnityEngine;

public class KeyboardBMenuInput : MonoBehaviour
{
    private PlayerEvents _playerEvents;
    BMenuEvents _bMenuEvents;
    public void Init(PlayerEvents playerEvents, BMenuEvents bMenuEvents)
    {
        _playerEvents = playerEvents;
        _bMenuEvents = bMenuEvents;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            _playerEvents.InvokeOnBMenuToggle();
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            _bMenuEvents.InvokeOnBMenuToggleRMB();
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            _bMenuEvents.InvokeOnBMenuToggle1();
        }
        if  (Input.GetKeyUp(KeyCode.Alpha2))
        {
            _bMenuEvents.InvokeOnBMenuToggle2();
        }
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            _bMenuEvents.InvokeOnBMenuToggle3();
        }
        if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            _bMenuEvents.InvokeOnBMenuToggle4();
        }
        if (Input.GetKeyUp(KeyCode.Alpha5))
        {
            _bMenuEvents.InvokeOnBMenuToggle5();
        }
        if (Input.GetKeyUp(KeyCode.Alpha6))
        {
            _bMenuEvents.InvokeOnBMenuToggle6();
        }
        if (Input.GetKeyUp(KeyCode.Alpha7))
        {
            _bMenuEvents.InvokeOnBMenuToggle7();
        }
    }
}