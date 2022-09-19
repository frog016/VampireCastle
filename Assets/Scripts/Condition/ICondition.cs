using System;

public interface ICondition
{
    bool IsConditionMet { get; }
    event Action OnConditionMet;
}
