using System;
using System.Collections.Generic;
using System.Linq;

public class ConditionHandler
{
    private readonly ICondition[] _conditions;
    private readonly List<Action> _tasks;

    public ConditionHandler(ICondition[] conditions)
    {
        _conditions = conditions;
        ObserveConditions(_conditions);
        _tasks = new List<Action>();
    }

    public void OnAllConditionsAreMet(Action action)
    {
        _tasks.Add(action);
    }

    private void CheckConditions()
    {
        if (_conditions.Any(condition => !condition.IsConditionMet))
            return;

        foreach (var task in _tasks)
            task?.Invoke();
    }

    private void ObserveConditions(ICondition[] conditions)
    {
        foreach (var condition in conditions)
            condition.OnConditionMet += CheckConditions;
    }
}
