using System;

public class ObservableVariable<T>
{
    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            ValueChangedEvent?.Invoke(_value);
        }
    }

    public event Action<T> ValueChangedEvent; 

    private T _value;

    public ObservableVariable()
    {
    }

    public ObservableVariable(T value)
    {
        Value = value;
    }
}