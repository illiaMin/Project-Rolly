using UnityEngine;

public class TurretAim : MonoBehaviour
{
    private Transform _aimTarget;
    private float _turnSpeedDegreesPerSecond = 150f;

    private Transform _gun;

    [SerializeField] private float _gunMaxAngle = 20f;   // Отклонение пушки
    [SerializeField] private float _gunTurnSpeed = 400f; // Скорость пушки

    private void LateUpdate()
    {
        if (_aimTarget == null) return;

        Vector2 toTarget = _aimTarget.position - transform.position;
        if (toTarget.sqrMagnitude < 0.0001f) return;

        // ===== ЦЕЛЬ В МИРОВЫХ КООРДИНАТАХ =====
        float worldAngle =
            Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg - 90f;

        Quaternion desiredTurretRotation =
            Quaternion.Euler(0f, 0f, worldAngle);

        // ===== ВРАЩАЕМ БАШНЮ =====
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            desiredTurretRotation,
            _turnSpeedDegreesPerSecond * Time.deltaTime
        );

        // ===== ВРАЩАЕМ ПУШКУ =====
        AimGun(worldAngle);
    }

    private void AimGun(float targetWorldAngle)
    {
        if (_gun == null) return;

        // Угол башни
        float turretAngle = transform.eulerAngles.z;

        // Разница между целью и башней
        float delta =
            Mathf.DeltaAngle(turretAngle, targetWorldAngle);

        // Ограничиваем пушку
        float clamped =
            Mathf.Clamp(delta, -_gunMaxAngle, _gunMaxAngle);

        // Целевой угол пушки (локально)
        Quaternion desiredGunRotation =
            Quaternion.Euler(0f, 0f, clamped);

        _gun.localRotation = Quaternion.RotateTowards(
            _gun.localRotation,
            desiredGunRotation,
            _gunTurnSpeed * Time.deltaTime
        );
    }

    public void Init(
        Transform target,
        float turretTurnSpeedDegreesPerSecond,
        Transform gun)
    {
        _aimTarget = target;
        _turnSpeedDegreesPerSecond = turretTurnSpeedDegreesPerSecond;
        _gun = gun;
    }
}