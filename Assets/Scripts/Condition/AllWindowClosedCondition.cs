using System;

public class AllWindowClosedCondition : ICondition
{
    public bool IsConditionMet { get; private set; }
    public event Action OnConditionMet;

    public AllWindowClosedCondition()
    {
        Window.OnWindowClosedEvent += CheckWindows;
    }

    private void CheckWindows()
    {
        if (Window.Count != 0)
            return;

        IsConditionMet = true;
        OnConditionMet?.Invoke();
    }
}
