using System;
using UnityEngine;

public class Teleport : InteractiveObject, IDependenteable
{
    [SerializeField] private Teleport _otherTeleport;

    public bool IsActive { get; private set; }

    private void Awake()
    {
        IsActive = true;
    }

    protected override void Interact(GameObject triggeredObject)
    {
        if (!IsActive)
            return;

        _otherTeleport.IsActive = false;
        triggeredObject.transform.position = _otherTeleport.transform.position;
    }

    public void InitializeDependency(IDependenteable otherDependenteable)
    {
        var dependable = otherDependenteable as Teleport;
        if (dependable == null)
            throw new InvalidCastException(
                $"{otherDependenteable} is not {nameof(Teleport)}. Can't cast first to second.");

        _otherTeleport = dependable;
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<Character>() == null)
            return;

        IsActive = true;
    }
}
