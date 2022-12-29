using UnityEngine;

public abstract class MoneyWallet : SavableScriptableObject
{
    [SerializeField] private float _balance;

    public readonly ObservableVariable<float> Balance = new ObservableVariable<float>();

    private void OnValidate()
    {
        Balance.Value = _balance;
    }

    public void AddMoney(float value)
    {
        Balance.Value += value;
    }

    public bool TrySpendMoney(float value)
    {
        if (!IsEnough(value))
            return false;

        Balance.Value += value;
        return true;
    }

    public bool IsEnough(float value) => _balance >= value;

    public override void OnAfterDeserialize()
    {
        Balance.Value = _balance;
    }
}