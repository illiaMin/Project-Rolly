using UnityEngine;

public class MouseAimTargetMover : MonoBehaviour, IAimTargetMover
{
    private Camera _camera;

    public void SetCamera(Camera camera)
    {
        _camera = camera;
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