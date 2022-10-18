using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Window : InteractiveObject
{ 
    public UnityEvent OnWindowClosed { get; private set; }

    private Animator _animator;

    private void Awake()
    {
        OnWindowClosed = new UnityEvent();
        _animator = GetComponentInChildren<Animator>();
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
        _animator.Play("WindowClosing");
        GetComponentInChildren<ParticleSystem>().Stop();
    }
}
