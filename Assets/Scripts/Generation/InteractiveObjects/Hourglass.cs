using UnityEngine;

public class Hourglass : InteractiveTime
{
    protected override void Interact(GameObject triggeredObject)
    {
        base.Interact(triggeredObject);
        Destroy(gameObject);
    }
}
