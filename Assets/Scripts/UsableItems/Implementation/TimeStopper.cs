using System;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class TimeStopper : IUsableItem
{
    [SerializeField] private float _duration;

    public void Use()
    {
        StopTime(_duration);
    }

    private async void StopTime(float duration)
    {
        Timer.Instance.StopTimer();
        await Task.Delay((int)(duration * 1000));
        Timer.Instance.StartTimer();
    }
}
