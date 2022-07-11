using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class InteractiveObject : MonoBehaviour
{
    [SerializeField] protected float _additionalTime;

    protected virtual void Interact(GameObject triggeredObject)
    {
        Timer.Instance.CurrentTime += _additionalTime;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<CharacterController>() == null)
            return;

        Interact(otherCollider.gameObject);
    }
}
