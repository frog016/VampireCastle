using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public abstract class InteractiveObject : MonoBehaviour
{
    [SerializeField] private bool _destroyOnInteract;
    [SerializeField] private UnityEvent _interactEventEditorOnly;

    protected abstract void Interact(GameObject triggeredObject);

    protected virtual void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<CharacterHealth>() == null)
            return;

        Interact(otherCollider.gameObject);
        _interactEventEditorOnly?.Invoke();

        if (_destroyOnInteract)
            Destroy();
    }
}
