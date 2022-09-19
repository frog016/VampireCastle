using System;
using System.Threading.Tasks;
using UnityEngine;

public class TimeStopper : IUsableItem
{
    private float _duration;
    private readonly Timer _timer;

    public TimeStopper(Timer timer, Parameters parameters)
    {
        _duration = parameters.Duration;
        _timer = timer;
    }

    public void Use()
    {
        StopTime(_duration);
    }

    private async void StopTime(float duration)
    {
        _timer.StopTimer();
        await Task.Delay((int)(duration * 1000));
        _timer.StartTimer();
    }

    [Serializable]
    public class Parameters
    {
        [SerializeField] private float _duration;

        public float Duration => _duration;
    }
}
