using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;
    [SerializeField] private Transform _frontTransform;

    private Image _slider;
    private Timer _timer;

    private void Awake()
    {
        _slider = _frontTransform.GetComponent<Image>();
        _timer = FindObjectOfType<Timer>();
    }

    private void Start()
    {
        _timer.OnTimerTickEvent.AddListener(ChangeValue);
    }

    private void ChangeValue()
    {
        _slider.fillAmount = _timer.CurrentTime / _timer.MaxTime;
        var lerpTime = 1 - _slider.fillAmount;
        _slider.color = Color.Lerp(_startColor, _endColor, lerpTime);
    }
}
