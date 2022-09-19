using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TimerBar : TextChanger
{
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;
    [SerializeField] private Transform _frontTransform;

    private Timer _timer;
    private Image _slider;

    private void Awake()
    {
        _slider = _frontTransform.GetComponent<Image>();
    }

    [Inject]
    public void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.OnTimerTickEvent += ChangeValue;
    }

    private void ChangeValue()
    {
        _slider.fillAmount = _timer.CurrentTime / _timer.MaxTime;
        var lerpTime = 1 - _slider.fillAmount;
        _slider.color = Color.Lerp(_startColor, _endColor, lerpTime);
        ChangeText((int)_timer.CurrentTime);
    }

    private void OnDestroy()
    {
        _timer.OnTimerTickEvent -= ChangeValue;
    }
}
