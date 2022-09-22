using System;
using UnityEngine;

public abstract class InteractiveTime : InteractiveObject
{
    [SerializeField] protected float _additionalTime;

    protected override void Interact(GameObject triggeredObject)
    {
        var character = triggeredObject.GetComponent<Character>();
        Action<float> action;
        if (_additionalTime > 0)
            action = character.ApplyHealth;
        else
            action = character.ApplyDamage;

        action(Mathf.Abs(_additionalTime));
    }
}
