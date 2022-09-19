using UnityEngine;

public class VampireTooth : MonoBehaviour, IUsableItem
{
    public void Use()
    {
        Timer.Instance.RestartTimer();
    }
}
