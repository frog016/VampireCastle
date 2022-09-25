using UnityEngine;

public class Teleport : InteractiveObject
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

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.GetComponent<Character>() == null)
            return;

        IsActive = true;
    }
}
