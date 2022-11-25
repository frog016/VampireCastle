using System;
using UnityEngine;

public class PressurePlate : InteractiveObject, IDependenteable
{
    [SerializeField] private OpenableWall _target;

    protected override void Interact(GameObject triggeredObject)
    {
        ActivateTargetObject();
        Destroy(this);
    }

    private void ActivateTargetObject()
    {
        _target.gameObject.SetActive(false);
    }

    public void InitializeDependency(IDependenteable otherDependenteable)
    {
        var dependable = otherDependenteable as OpenableWall;
        if (dependable == null)
            throw new InvalidCastException(
                $"{otherDependenteable} is not {nameof(OpenableWall)}. Can't cast first to second.");

        _target = dependable;
    }
}
