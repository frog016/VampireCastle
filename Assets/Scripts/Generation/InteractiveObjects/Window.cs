using System;
using UnityEngine;

public class Window : HealthChangerObject
{
    public static int Count;
    public static event Action OnWindowClosedEvent;

    private void Awake()
    {
        Count++;
    }

    protected override void Interact(GameObject triggeredObject)
    {
        base.Interact(triggeredObject);
        CloseWindow();
    }

    private void CloseWindow()
    {
        Count--;
        OnWindowClosedEvent?.Invoke();
        var sprites = GetComponentsInChildren<SpriteRenderer>(true);
        sprites[0].gameObject.SetActive(false);
        sprites[1].gameObject.SetActive(true);
    }
}
