using UnityEngine;
using UnityEngine.Events;

public class RobotEvents : MonoBehaviour
{
    #region OnShot
    
    private readonly UnityEvent<OnShotEventContext> _onShot 
        = new UnityEvent<OnShotEventContext>();

    public void InvokeOnShot(OnShotEventContext context) 
        => _onShot.Invoke(context);
    public void AddListenerToOnShot(UnityAction<OnShotEventContext> listener) 
        => _onShot.AddListener(listener);
        
    public void RemoveListenerFromOnShot(UnityAction<OnShotEventContext> listener) 
        => _onShot.RemoveListener(listener);

    
    #endregion
    
    #region OnDMGRecieved
    
    private readonly UnityEvent _onDMGRecieved 
        = new UnityEvent();

    public void InvokeOnDMGRecieved() 
        => _onDMGRecieved.Invoke();
    public void AddListenerToOnDMGRecieved(UnityAction listener) 
        => _onDMGRecieved.AddListener(listener);
        
    public void RemoveListenerFromOnShot(UnityAction listener) 
        => _onDMGRecieved.RemoveListener(listener);

    
    #endregion
    
}
