using System;
using UnityEngine;
using UnityEngine.Events;

public class Window : HealthChangerObject
{
    public static int Count;
    public static event Action OnWindowClosedEvent;

    [SerializeField] private UnityEvent _onWindowClosedEvent;

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
        GetComponent<Collider2D>().enabled = false;
        OnWindowClosedEvent?.Invoke();
        _onWindowClosedEvent.Invoke();
    }
}
