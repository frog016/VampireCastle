using System;

public class ObservableVariable<T>
{
    public T Value
    {
        get => _value;
        set
        {
            if (!_validator(value))
                return;

            _value = value;
            ValueChangedEvent?.Invoke(_value);
        }
    }

    public event Action<T> ValueChangedEvent; 

    private T _value;
    private Func<T, bool> _validator = _ => true;

    public ObservableVariable()
    {
    }

    public ObservableVariable(T value)
    {
        Value = value;
    }

    public ObservableVariable(Func<T, bool> validator)
    {
        _validator = validator;
    }

    public ObservableVariable(T value, Func<T, bool> validator)
    {
        Value = value;
        _validator = validator;
    }

    public void ChangeValidator(Func<T, bool> validator) => _validator = validator;
}