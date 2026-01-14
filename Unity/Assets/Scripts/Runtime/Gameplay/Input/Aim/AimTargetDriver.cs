using UnityEngine;

public class AimTargetDriver : MonoBehaviour
{
    private Transform _aimTarget;
    private MonoBehaviour _moverBehaviour;

    private IAimTargetMover _mover;

    private void Awake()
    {
        _mover = _moverBehaviour as IAimTargetMover;
        if (_mover == null && _moverBehaviour != null)
        {
            Debug.LogError("Mover does not implement IAimTargetMover.", this);
        }
    }

    private void Update()
    {
        if (_mover == null) return;
        if (_aimTarget == null) return;

        _mover.Move(_aimTarget);
    }

    public void SetAimTarget(Transform aimTarget)
    {
        _aimTarget = aimTarget;
    }
    public void SetMover(MonoBehaviour moverBehaviour)
    {
        _moverBehaviour = moverBehaviour;
        _mover = _moverBehaviour as IAimTargetMover;
    }
}