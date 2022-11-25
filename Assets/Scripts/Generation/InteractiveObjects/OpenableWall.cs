using System;
using UnityEngine;

public class OpenableWall : MonoBehaviour, IDependenteable
{
    public void InitializeDependency(IDependenteable otherDependenteable)
    {
        var dependable = otherDependenteable as PressurePlate;
        if (dependable == null)
            throw new InvalidCastException(
                $"{otherDependenteable} is not {nameof(PressurePlate)}. Can't cast first to second.");
    }
}
