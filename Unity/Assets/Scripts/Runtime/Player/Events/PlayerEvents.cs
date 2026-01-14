using UnityEngine;
using UnityEngine.Events;

public class PlayerEvents : MonoBehaviour
{
    #region OnShot
    
        private readonly UnityEvent<Transform> _onShot 
            = new UnityEvent<Transform>();

        public void InvokeOnShot(Transform turret) 
            => _onShot.Invoke(turret);
        public void AddListenerToOnShot(UnityAction<Transform> listener) 
            => _onShot.AddListener(listener);
        
        public void RemoveListenerFromOnShot(UnityAction<Transform> listener) 
            => _onShot.RemoveListener(listener);

    
    #endregion

    
    #region OnTurretChanged
    
        private readonly UnityEvent<Turret> _onTurretChanged 
            = new UnityEvent<Turret>();
    
        public void InvokeOnTurretChanged(Turret turret) 
            => _onTurretChanged.Invoke(turret);
        public void AddListenerToOnTurretChanged(UnityAction<Turret> listener) 
            => _onTurretChanged.AddListener(listener);
        
        public void RemoveListenerFromOnTurretChanged(UnityAction<Turret> listener) 
            => _onTurretChanged.RemoveListener(listener);

    #endregion
    
    
}