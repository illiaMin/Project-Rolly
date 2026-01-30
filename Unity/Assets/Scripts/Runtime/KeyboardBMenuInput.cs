using UnityEngine;

public sealed class KeyboardBMenuInput : MonoBehaviour
{
    private PlayerEvents _playerEvents;

    public void Init(PlayerEvents playerEvents)
    {
        _playerEvents = playerEvents;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            _playerEvents.InvokeOnBMenuToggle();
        }
    }
}