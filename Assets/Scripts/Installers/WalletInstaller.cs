using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "WalletInstaller", menuName = "Installers/WalletInstaller")]
public class WalletInstaller : ScriptableObjectInstaller<WalletInstaller>
{
    [SerializeField] private MoneyWallet[] _wallets;

    public override void InstallBindings()
    {
        foreach (var wallet in _wallets)
            Container
                .Bind(wallet.GetType())
                .FromScriptableObject(wallet)
                .AsSingle();
        
    }
}