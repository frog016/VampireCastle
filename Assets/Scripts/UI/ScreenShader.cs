using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScreenShader : MonoBehaviour
{
    [SerializeField] private float _shadingDelay;
    [SerializeField] private float _shadingSpeed;
    [SerializeField] private Image _shade;

    private Timer _timer;
    private ConditionHandler _conditionHandler;

    [Inject]
    public void Initialize(Timer timer, ConditionHandler conditionHandler)
    {
        _timer = timer;
        _conditionHandler = conditionHandler;
    }

    private void OnEnable() => _conditionHandler.ConditionCompletedEvent += StartShading;

    private void StartShading()
    {
        StartCoroutine(ShadeCoroutine());
    }

    private IEnumerator ShadeCoroutine()
    {
        _timer.StopTimer();
        
        yield return TransitColorTo(Color.clear, Color.black, 1);
        yield return new WaitForSeconds(_shadingDelay);
        yield return TransitColorTo(Color.black, Color.clear, 0);

        _timer.StartTimer();
    }

    private IEnumerator TransitColorTo(Color from, Color to, float threshold)
    {
        var elapsedTime = 0f;
        while (Math.Abs(_shade.color.a - threshold) > 1e-7)
        {
            elapsedTime = Mathf.Clamp(elapsedTime + _shadingSpeed * Time.deltaTime, 0, 1);
            _shade.color = Color.Lerp(from, to, elapsedTime);
            yield return null;
        }
    }

    private void OnDisable() => _conditionHandler.ConditionCompletedEvent -= StartShading;
}
