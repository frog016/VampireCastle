using UnityEngine;

public class Window : InteractiveObject
{
    protected override void Interact(GameObject triggeredObject)
    {
        base.Interact(triggeredObject);
        CloseWindow();
        Destroy(this);
    }

    private void CloseWindow()
    {
        var sprites = GetComponentsInChildren<SpriteRenderer>(true);
        sprites[0].gameObject.SetActive(false);
        sprites[1].gameObject.SetActive(true);
    }
}
