using System.Linq;
using Edgar.Unity;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GenerationInstaller", menuName = "Installers/GenerationInstaller")]
public class GenerationInstaller : ScriptableObjectInstaller<GenerationInstaller>
{
    [SerializeField] private GeneratorProvider _generatorProvider;
    [SerializeField] private DungeonGeneratorPostProcessingGrid2D[] _postProcessingTasks;

    public override void InstallBindings()
    {
        Container.BindInstance(_generatorProvider);
        Container.Bind<IFactory<GameObject>>().To<InteractiveObjectFactory>().AsSingle();

        var interactiveType = typeof(InteractiveObject);
        Container.Bind(
                interactiveType
                    .Assembly
                    .ExportedTypes
                    .Where(t => interactiveType.IsAssignableFrom(t) && !t.IsAbstract))
            .AsSingle();

        foreach (var task in _postProcessingTasks)
        {
            Container
                .Bind(task.GetType())
                .FromScriptableObject(task)
                .AsTransient();

            Container.Inject(task);
        }
    }
}