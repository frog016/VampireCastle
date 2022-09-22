using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class InteractiveObject : MonoBehaviour
{
    protected abstract void Interact(GameObject triggeredObject);

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<Character>() == null)
            return;

        Interact(otherCollider.gameObject);
    }
}
