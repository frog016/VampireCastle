using System;
using UnityEngine;

public abstract class MoneyWallet<T> : SerializableScriptableObject<T> where T : SingletonScriptableObject<T>
{
    [SerializeField] protected float _balance;

    public float Balance => _balance;
    public event Action<float> OnBalanceUpdatedEvent;

    public void AddMoney(float value)
    {
        _balance += value;
        OnBalanceUpdatedEvent?.Invoke(_balance);
    }

    public bool TrySpendMoney(float value)
    {
        if (!IsEnough(value))
            return false;

        _balance -= value;
        OnBalanceUpdatedEvent?.Invoke(_balance);
        return true;
    }

    public bool IsEnough(float value) => _balance >= value;
}
