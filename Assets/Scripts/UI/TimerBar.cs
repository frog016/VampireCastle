using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;
    [SerializeField] private Transform _frontTransform;
    [SerializeField] private Text _timerText;
    [SerializeField] private Animator _animator;

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
        var time = Timer.Instance.CurrentTime;
        _animator.SetFloat("Time", time);

        _slider.fillAmount = time / Timer.Instance.MaxTime;
        var lerpTime = 1 - _slider.fillAmount;
        _slider.color = Color.Lerp(_startColor, _endColor, lerpTime);
        _timerText.text = ((int)time).ToString();
    }
}
