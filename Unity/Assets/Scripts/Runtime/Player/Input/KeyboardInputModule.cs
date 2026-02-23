using UnityEngine;

public class KeyboardInputModule : InputModule
{
    [SerializeField] MouseAimTargetMover _mouseAimTargetMover;
    [SerializeField] AimTargetDriver _aimTargetDriver;
    [SerializeField] MouseInputShot _mouseInputShot;
    [SerializeField] KeyboardBMenuInput _keyboardBMenuInput;
    [SerializeField] KeyboardDashInput _keyboardDashInput;
    
    public override void Init(InputContext c)
    {
        _mouseAimTargetMover.SetCamera(c.Camera);
        _aimTargetDriver.SetAimTarget(c.Target);
        _aimTargetDriver.SetMover(_mouseAimTargetMover);
        c.PlayerEvents.AddListenerToOnTurretChanged(_mouseInputShot.SetTurret);
        _keyboardBMenuInput.Init(c.PlayerEvents, c.BMenuEvents);
        _keyboardDashInput.Init(c.PlayerEvents);
    }
}