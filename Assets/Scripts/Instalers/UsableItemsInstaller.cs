using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "UsableItemsInstaller", menuName = "Installers/UsableItemsInstaller")]
public class UsableItemsInstaller : ScriptableObjectInstaller<UsableItemsInstaller>
{
    [SerializeField] private IUsableItem[] _usableItems;

    public override void InstallBindings()
    {
    }
}