using UnityEngine;

public class Garlic : InteractiveObject
{
    protected override void Interact(GameObject triggeredObject)
    {
        base.Interact(triggeredObject);
        Destroy(gameObject);
    }
}
