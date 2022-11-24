using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "DifficultyInstaller", menuName = "Installers/DifficultyInstaller")]
public class DifficultyInstaller : ScriptableObjectInstaller<DifficultyInstaller>
{
    [SerializeField] private TimerConfigurator _configurator;

    public override void InstallBindings()
    {
        Container.QueueForInject(_configurator);
    }
}