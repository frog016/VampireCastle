using System;

[Serializable]
public class VampireTooth : IUsableItem
{
    public void Use()
    {
        Timer.Instance.RestartTimer();
    }
}
