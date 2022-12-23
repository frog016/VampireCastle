using System;

public class AllWindowClosedCondition : ICondition
{
    public bool IsConditionMet { get; private set; }
    public event Action OnConditionMet;

    public AllWindowClosedCondition()
    {
        Window.WindowClosingEvent += CheckWindows;
    }

    private void CheckWindows(int remainingCount)
    {
        if (remainingCount > 0)
            return;

        IsConditionMet = true;
        OnConditionMet?.Invoke();
    }
}
