using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GenerationInstaller", menuName = "Installers/GenerationInstaller")]
public class GenerationInstaller : ScriptableObjectInstaller<GenerationInstaller>
{
    [SerializeField] private GeneratorProvider _generatorProvider; 

    public override void InstallBindings()
    {
        Container.BindInstance(_generatorProvider);
    }
}