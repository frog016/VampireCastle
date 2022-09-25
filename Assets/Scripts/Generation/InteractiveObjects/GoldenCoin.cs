using UnityEngine;
using Zenject;

public class GoldenCoin : InteractiveObject
{
    [SerializeField] private float _value;

    private MoneyWallet _wallet;

    [Inject]
    public void Initialize(GoldenMoneyWallet wallet)
    {
        _wallet = wallet;
    }

    protected override void Interact(GameObject triggeredObject)
    {
        _wallet.AddMoney(_value);
        Destroy(gameObject);
    }
}
