using UnityEngine;

public class TurretAim : MonoBehaviour
{
    private Transform _aimTarget;
    private float _turnSpeedDegreesPerSecond = 150f;

    private void LateUpdate()
    {
        if (_aimTarget == null) return;

        Vector2 toTarget = _aimTarget.position - transform.position;
        if (toTarget.sqrMagnitude < 0.0001f) return;

        float angle = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg - 90f;
        Quaternion desiredRotation = Quaternion.Euler(0f, 0f, angle);

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            desiredRotation,
            _turnSpeedDegreesPerSecond * Time.deltaTime
        );
    }

    public void Init(Transform target, float turretTurnSpeedDegreesPerSecond)
    {
        _aimTarget = target;
        _turnSpeedDegreesPerSecond = turretTurnSpeedDegreesPerSecond;
    }
}