using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;
    [SerializeField] private Transform _frontTransform;
    [SerializeField] private Text _timerText;

    private Image _slider;

    private void Awake()
    {
        _slider = _frontTransform.GetComponent<Image>();
    }

    private void Start()
    {
        Timer.Instance.OnTimerTickEvent.AddListener(ChangeValue);
    }

    private void ChangeValue()
    {
        _slider.fillAmount = Timer.Instance.CurrentTime / Timer.Instance.MaxTime;
        var lerpTime = 1 - _slider.fillAmount;
        _slider.color = Color.Lerp(_startColor, _endColor, lerpTime);
        _timerText.text = ((int)Timer.Instance.CurrentTime).ToString();
    }
}
