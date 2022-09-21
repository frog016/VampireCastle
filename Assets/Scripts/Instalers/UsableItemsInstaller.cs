using System.Linq;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "UsableItemsInstaller", menuName = "Installers/UsableItemsInstaller")]
public class UsableItemsInstaller : ScriptableObjectInstaller<UsableItemsInstaller>
{
    [SerializeField] private Shield.Parameters _shieldParameters; 
    [SerializeField] private TimeStopper.Parameters _timeStopperParameters;
    [SerializeField] private LevelBuster.Parameters _levelBusterParameters;

    public override void InstallBindings()
    {
        Container.BindInstance(_shieldParameters).IfNotBound();
        Container.BindInstance(_timeStopperParameters).IfNotBound();
        Container.BindInstance(_levelBusterParameters).IfNotBound();

        var type = typeof(IUsableItem);
        Container
            .Bind(type)
            .To(type.Assembly.ExportedTypes.Where(t => type.IsAssignableFrom(t) && t != type))
            .AsSingle();
    }
}