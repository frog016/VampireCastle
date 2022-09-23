using UnityEngine;

public class PressurePlate : InteractiveObject
{
    [SerializeField] private GameObject _target;

    protected override void Interact(GameObject triggeredObject)
    {
        ActivateTargetObject();
        Destroy(this);
    }

    private void ActivateTargetObject()
    {
        _target.SetActive(false);
    }
}
