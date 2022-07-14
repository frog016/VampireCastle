using UnityEngine;
using UnityEngine.Events;

public class Window : InteractiveObject
{
    public UnityEvent OnWindowClosed { get; private set; }

    private void Awake()
    {
        OnWindowClosed = new UnityEvent();
    }

    protected override void Interact(GameObject triggeredObject)
    {
        base.Interact(triggeredObject);
        CloseWindow();
        Destroy(this);
    }

    private void CloseWindow()
    {
        OnWindowClosed.Invoke();
        var sprites = GetComponentsInChildren<SpriteRenderer>(true);
        sprites[0].gameObject.SetActive(false);
        sprites[1].gameObject.SetActive(true);
    }
}
