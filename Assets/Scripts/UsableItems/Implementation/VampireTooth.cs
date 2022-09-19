using System;

[Serializable]
public class VampireTooth : IUsableItem
{
    private readonly Timer _timer;

    public VampireTooth(Timer timer)
    {
        _timer = timer;
    }

    public void Use()
    {
        _timer.RestartTimer();
    }
}
