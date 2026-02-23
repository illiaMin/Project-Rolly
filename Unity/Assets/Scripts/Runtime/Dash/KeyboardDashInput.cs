using UnityEngine;

public class KeyboardDashInput : MonoBehaviour
{
    private PlayerEvents _playerEvents;
    
    //TODO make an input for dash 

    public void Init(PlayerEvents playerEvents)
    {
        _playerEvents = playerEvents;
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _playerEvents.InvokeOnDashToggle();
        }
    }
}
