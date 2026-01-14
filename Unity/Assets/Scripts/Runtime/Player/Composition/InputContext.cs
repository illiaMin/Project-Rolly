using UnityEngine;

public class InputContext
{
    public readonly PlayerEvents PlayerEvents;
    public readonly Camera Camera;
    public readonly Transform Target;
    public InputContext(PlayerEvents playerEvents, Camera camera, Transform target)
    {
        PlayerEvents =  playerEvents;
        Camera = camera;
        Target = target;
    }
}
