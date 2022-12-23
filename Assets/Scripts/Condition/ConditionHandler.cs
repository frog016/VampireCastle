using System;
using UnityEngine;

public class ConditionHandler : MonoBehaviour
{
    public event Action ConditionCompletedEvent;

    private void OnEnable() => Subscribe();

    private void OnDisable() => Unsubscribe();

    private void Subscribe()
    {
        Window.WindowClosingEvent += CheckCondition;
    }

    private void Unsubscribe()
    {
        Window.WindowClosingEvent -= CheckCondition;
    }

    private void CheckCondition(int remainingCount)
    {
        if (remainingCount > 0)
            return;

        ConditionCompletedEvent?.Invoke();
    }
}
