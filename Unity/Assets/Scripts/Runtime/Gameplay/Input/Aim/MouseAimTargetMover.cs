using UnityEngine;

public class MouseAimTargetMover : MonoBehaviour, IAimTargetMover
{
    [SerializeField] private Camera _camera;

    private void Awake()
    {
        if (_camera == null)
        {
            _camera = Camera.main;
        }
    }

    public void Move(Transform aimTarget)
    {
        if (_camera == null) return;
        if (aimTarget == null) return;
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 worldPosition = _camera.ScreenToWorldPoint(mouseScreenPosition);

        aimTarget.position = new Vector3(worldPosition.x, worldPosition.y, aimTarget.position.z);
    }
}