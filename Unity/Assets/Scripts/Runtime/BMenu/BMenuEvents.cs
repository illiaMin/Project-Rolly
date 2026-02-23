using UnityEngine;
using UnityEngine.Events;

public class BMenuEvents : MonoBehaviour
{
    #region OnBMenuToggleToMainPage

    private readonly UnityEvent _onBMenuToggleToMainPage = new UnityEvent();

    public void InvokeOnBMenuToggleToMainPage() => _onBMenuToggleToMainPage.Invoke();
    public void AddListenerToOnBMenuToggleToMainPage(UnityAction listener) 
        => _onBMenuToggleToMainPage.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggleToMainPage(UnityAction listener) 
        => _onBMenuToggleToMainPage.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggleToMainGunPage

    private readonly UnityEvent _onBMenuToggleToMainGunPage = new UnityEvent();

    
    public void InvokeOnBMenuToggleToMainGunPage() 
        => _onBMenuToggleToMainGunPage.Invoke();
    
    public void AddListenerToOnBMenuToggleToMainGunPage(UnityAction listener) 
        => _onBMenuToggleToMainGunPage.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggleToMainGunPage(UnityAction listener) 
        => _onBMenuToggleToMainGunPage.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggleToSecondaryGunPage

    private readonly UnityEvent _onBMenuToggleToSecondaryGunPage = new UnityEvent();

    public void InvokeOnBMenuToggleToSecondaryGunPage() 
        => _onBMenuToggleToSecondaryGunPage.Invoke();
    
    public void AddListenerToOnBMenuToggleToSecondaryGunPage(UnityAction listener) 
        => _onBMenuToggleToSecondaryGunPage.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggleToSecondaryGunPage(UnityAction listener) 
        => _onBMenuToggleToSecondaryGunPage.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggleToGunPage

    private readonly UnityEvent _onBMenuToggleToGunPage = new UnityEvent();

    public void InvokeOnBMenuToggleToGunPage() => _onBMenuToggleToGunPage.Invoke();
    public void AddListenerToOnBMenuToggleToGunPage(UnityAction listener) 
        => _onBMenuToggleToGunPage.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggleToGunPage(UnityAction listener) 
        => _onBMenuToggleToGunPage.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggleToAuxiliaryPage

    private readonly UnityEvent _onBMenuToggleToAuxiliaryPage = new UnityEvent();

    public void InvokeOnBMenuToggleToAuxiliaryPage() 
        => _onBMenuToggleToAuxiliaryPage.Invoke();
    
    public void AddListenerToOnBMenuToggleToAuxiliaryPage(UnityAction listener) 
        => _onBMenuToggleToAuxiliaryPage.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggleToAuxiliaryPage(UnityAction listener) 
        => _onBMenuToggleToAuxiliaryPage.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggleToRiflePage

    private readonly UnityEvent _onBMenuToggleToRiflePage = new UnityEvent();

    public void InvokeOnBMenuToggleToRiflePage() 
        => _onBMenuToggleToRiflePage.Invoke();
    
    public void AddListenerToOnBMenuToggleToRiflePage(UnityAction listener) 
        => _onBMenuToggleToRiflePage.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggleToRiflePage(UnityAction listener) 
        => _onBMenuToggleToRiflePage.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggleToWheelsPage

    private readonly UnityEvent _onBMenuToggleToWheelsPage = new UnityEvent();

    public void InvokeOnBMenuToggleToWheelsPage() 
        => _onBMenuToggleToWheelsPage.Invoke();
    
    public void AddListenerToOnBMenuToggleToWheelsPage(UnityAction listener) 
        => _onBMenuToggleToWheelsPage.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggleToWheelsPage(UnityAction listener) 
        => _onBMenuToggleToWheelsPage.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggleToWheelsPage

    private readonly UnityEvent _onBMenuToggleToBatteryPage = new UnityEvent();

    public void InvokeOnBMenuToggleToBatteryPage() 
        => _onBMenuToggleToBatteryPage.Invoke();
    
    public void AddListenerToOnBMenuToggleToBatteryPage(UnityAction listener) 
        => _onBMenuToggleToBatteryPage.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggleToBatteryPage(UnityAction listener) 
        => _onBMenuToggleToBatteryPage.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggleToWheelsPage

    private readonly UnityEvent _onBMenuToggleToIdCardPage = new UnityEvent();

    public void InvokeOnBMenuToggleToIdCardPage() 
        => _onBMenuToggleToIdCardPage.Invoke();
    
    public void AddListenerToOnBMenuToggleToIdCardPage(UnityAction listener) 
        => _onBMenuToggleToIdCardPage.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggleToIdCardPage(UnityAction listener) 
        => _onBMenuToggleToIdCardPage.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggleClose

    private readonly UnityEvent _onBMenuToggleClose = new UnityEvent();

    public void InvokeOnBMenuToggleClose() 
        => _onBMenuToggleClose.Invoke();
    
    public void AddListenerToOnBMenuToggleClose(UnityAction listener) 
        => _onBMenuToggleClose.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggleClose(UnityAction listener) 
        => _onBMenuToggleClose.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggleRMB

    private readonly UnityEvent _onBMenuToggleRMB = new UnityEvent();

    public void InvokeOnBMenuToggleRMB() 
        => _onBMenuToggleRMB.Invoke();
    
    public void AddListenerToOnBMenuToggleRMB(UnityAction listener) 
        => _onBMenuToggleRMB.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggleRMB() 
        => _onBMenuToggleRMB.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggle1

    private readonly UnityEvent _onBMenuToggle1 = new UnityEvent();

    public void InvokeOnBMenuToggle1() 
        => _onBMenuToggle1.Invoke();
    
    public void AddListenerToOnBMenuToggle1(UnityAction listener) 
        => _onBMenuToggle1.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggle1() 
        => _onBMenuToggle1.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggle2

    private readonly UnityEvent _onBMenuToggle2 = new UnityEvent();

    public void InvokeOnBMenuToggle2() 
        => _onBMenuToggle2.Invoke();
    
    public void AddListenerToOnBMenuToggle2(UnityAction listener) 
        => _onBMenuToggle2.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggle2() 
        => _onBMenuToggle2.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggle3

    private readonly UnityEvent _onBMenuToggle3 = new UnityEvent();

    public void InvokeOnBMenuToggle3() 
        => _onBMenuToggle3.Invoke();
    
    public void AddListenerToOnBMenuToggle3(UnityAction listener) 
        => _onBMenuToggle3.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggle3() 
        => _onBMenuToggle3.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggle4

    private readonly UnityEvent _onBMenuToggle4 = new UnityEvent();

    public void InvokeOnBMenuToggle4() 
        => _onBMenuToggle4.Invoke();
    
    public void AddListenerToOnBMenuToggle4(UnityAction listener) 
        => _onBMenuToggle4.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggle4() 
        => _onBMenuToggle4.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggle5

    private readonly UnityEvent _onBMenuToggle5 = new UnityEvent();

    public void InvokeOnBMenuToggle5() 
        => _onBMenuToggle5.Invoke();
    
    public void AddListenerToOnBMenuToggle5(UnityAction listener) 
        => _onBMenuToggle5.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggle5() 
        => _onBMenuToggle5.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggle6

    private readonly UnityEvent _onBMenuToggle6 = new UnityEvent();

    public void InvokeOnBMenuToggle6() 
        => _onBMenuToggle6.Invoke();
    
    public void AddListenerToOnBMenuToggle6(UnityAction listener) 
        => _onBMenuToggle6.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggle6() 
        => _onBMenuToggle6.RemoveAllListeners();

    #endregion
    
    #region OnBMenuToggle7

    private readonly UnityEvent _onBMenuToggle7 = new UnityEvent();

    public void InvokeOnBMenuToggle7() 
        => _onBMenuToggle7.Invoke();
    
    public void AddListenerToOnBMenuToggle7(UnityAction listener) 
        => _onBMenuToggle7.AddListener(listener);
    
    public void RemoveAllListenersFromOnBMenuToggle7() 
        => _onBMenuToggle7.RemoveAllListeners();

    #endregion
    
    #region OnBMenuUpdateText

    private readonly UnityEvent<string> _onBMenuUpdateText = new UnityEvent<string>();

    public void InvokeOnBMenuUpdateText(string text) 
        => _onBMenuUpdateText.Invoke(text);
    
    public void AddListenerToOnBMenuUpdateText(UnityAction<string> listener) 
        => _onBMenuUpdateText.AddListener(listener);
    
    public void RemoveListenersFromOnBMenuUpdateText(UnityAction<string> listener) 
        => _onBMenuUpdateText.RemoveAllListeners();

    #endregion
}
