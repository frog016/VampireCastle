using UnityEngine;

public class Hourglass : InteractiveObject
{
    protected override void Interact(GameObject triggeredObject)
    {
        base.Interact(triggeredObject);
        Destroy(gameObject);
    }
}
