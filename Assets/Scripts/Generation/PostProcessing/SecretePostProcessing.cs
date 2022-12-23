using Edgar.Unity;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Edgar/Post processing/Secrete", fileName = "SecretePostProcessing")]
public class SecretePostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        var first = level.RoomInstances.First().RoomTemplateInstance.GetComponentInChildren<IDependenteable>();
        var second = level.RoomInstances.Last().RoomTemplateInstance.GetComponentInChildren<IDependenteable>();

        first.InitializeDependency(second);
        second.InitializeDependency(first);
    }
}
