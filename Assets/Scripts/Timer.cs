using UnityEngine;
using UnityEngine.Events;

public class Timer : SingletonObject<Timer>
{
    [SerializeField] private float _maxTime;
    [SerializeField] private float _tickSpeed;

    public float CurrentTime { get => _currentTime; set => _currentTime = Mathf.Clamp(value, 0, _maxTime); }
    public float TickSpeed { get => _tickSpeed; set => _tickSpeed = value; }
    public UnityEvent OnTimerTickEvent { get; private set; }
    public float MaxTime => _maxTime;

    private float _currentTime;
    private bool _isActive;

    protected override void Awake()
    {
        base.Awake();
        CurrentTime = _maxTime;
        OnTimerTickEvent = new UnityEvent();
        _isActive = true;
    }

    private void Update()
    {
        if (!_isActive)
            return;

        CurrentTime -= _tickSpeed * Time.deltaTime;
        OnTimerTickEvent.Invoke();

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
}
