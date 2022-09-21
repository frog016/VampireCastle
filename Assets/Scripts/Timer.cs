using System;
using UnityEngine;

public class Timer : MonoBehaviour
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
        var delta = _isActive ? Time.deltaTime : 0;

        CurrentTime -= _tickSpeed * delta;
        OnTimerTickEvent?.Invoke();

        if (CurrentTime < 1e-5)
            StopTimer();
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
}
