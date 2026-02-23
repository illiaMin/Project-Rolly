using UnityEngine;

public class InputContext
{
    public readonly PlayerEvents PlayerEvents;
    public readonly Camera Camera;
    public readonly Transform Target;
    public readonly BMenuEvents BMenuEvents;
    public InputContext(
        PlayerEvents playerEvents, 
        Camera camera, 
        Transform target,
        BMenuEvents bMenuEvents)
    {
        PlayerEvents =  playerEvents;
        Camera = camera;
        Target = target;
        BMenuEvents = bMenuEvents;
    }
}
