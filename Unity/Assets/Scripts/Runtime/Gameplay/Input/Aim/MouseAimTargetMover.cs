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

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.forward, Vector3.zero);

        if (plane.Raycast(ray, out float enter) == false) return;

        Vector3 world = ray.GetPoint(enter);
        aimTarget.position = new Vector3(world.x, world.y, aimTarget.position.z);
    }
}