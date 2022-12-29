using System;
using UnityEngine;

public class Timer : MonoBehaviour, IConfigurable<float>
{
    [SerializeField] private float _maxTime;
    [SerializeField] private float _tickSpeed;

    public event Action OnTimerTickEvent;
    public float CurrentTime { get => _currentTime; set => _currentTime = Mathf.Clamp(value, 0, _maxTime); }
    public float TickSpeed { get => _tickSpeed; set => _tickSpeed = value; }
    public float MaxTime => _maxTime;

    private float _currentTime;
    private bool _isActive;

    private void Awake()
    {
        CurrentTime = _maxTime;
        _isActive = true;
    }

    private void Update()
    {
        if (!_isActive)
            return;

        Tick();
    }

    public void Configure(float value)
    {
        TickSpeed = value;
    }

    public void StartTimer()
    {
        _isActive = true;
    }

    public void StopTimer()
    {
        _isActive = false;
    }

    public void RestartTimer()
    {
        CurrentTime = MaxTime;
    }

    private void Tick()
    {
        var deltaTime = Time.deltaTime;
        CurrentTime = Mathf.Max(CurrentTime - _tickSpeed * deltaTime, 0);
        OnTimerTickEvent?.Invoke();

        if (CurrentTime < 1e-5)
            StopTimer();
    }
}
