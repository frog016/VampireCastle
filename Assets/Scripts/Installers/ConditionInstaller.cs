using System.Linq;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ConditionInstaller", menuName = "Installers/ConditionInstaller")]
public class ConditionInstaller : ScriptableObjectInstaller<ConditionInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<ConditionHandler>().AsSingle();

        var type = typeof(ICondition);
        Container
            .Bind(type)
            .To(type.Assembly.ExportedTypes
                .Where(t => type.IsAssignableFrom(t) && !t.IsInterface))
            .AsTransient();
    }
}