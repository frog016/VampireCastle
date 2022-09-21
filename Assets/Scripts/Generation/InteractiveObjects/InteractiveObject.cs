using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class InteractiveObject : MonoBehaviour
{
    [SerializeField] protected float _additionalTime;

    protected virtual void Interact(GameObject triggeredObject)
    {
        var character = triggeredObject.GetComponent<Character>();
        Action<float> action;
        if (_additionalTime > 0)
            action = character.ApplyHealth;
        else
            action = character.ApplyDamage;

        action(Mathf.Abs(_additionalTime));
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<Character>() == null)
            return;

        Interact(otherCollider.gameObject);
    }
}
