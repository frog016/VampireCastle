using System;
using UnityEngine;

public class HealthChangerObject : InteractiveObject
{
    [SerializeField] protected float _healthValueDelta;
    [SerializeField] private bool _destroyOnInteract;

    protected override void Interact(GameObject triggeredObject)
    {
        var character = triggeredObject.GetComponent<Character>();
        Action<float> action;
        if (_healthValueDelta > 0)
            action = character.ApplyHealth;
        else
            action = character.ApplyDamage;

        action(Mathf.Abs(_healthValueDelta));

        if (_destroyOnInteract)
            Destroy(gameObject);
    }
}
