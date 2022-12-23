using UnityEngine;

public class HealthChangerObject : InteractiveObject
{
    [SerializeField] protected float _healthValueDelta;

    protected override void Interact(GameObject triggeredObject)
    {
        var character = triggeredObject.GetComponent<CharacterHealth>();
        character.ChangeHealth(_healthValueDelta);
    }
}
