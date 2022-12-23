using System;
using UnityEngine;
using UnityEngine.Events;

public class Window : HealthChangerObject
{
    [SerializeField] private UnityEvent InteractedEventEditorOnly;

    public static event Action<int> WindowClosingEvent;

    private static int _createdObjectAmount;

    private void Awake() => _createdObjectAmount++;

    protected override void Destroy()
    {
        WindowClosingEvent?.Invoke(_createdObjectAmount - 1);
        InteractedEventEditorOnly.Invoke();
        Destroy(this);
    }

    private void OnDestroy() => _createdObjectAmount--;
}