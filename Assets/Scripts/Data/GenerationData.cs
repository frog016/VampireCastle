using Edgar.Unity;
using UnityEngine;

[CreateAssetMenu(menuName = "Generation/GenerationData", fileName = "GenerationData")]
public class GenerationData : ScriptableObject
{
    [SerializeField] private FixedLevelGraphConfigGrid2D _graphConfig;
    [SerializeField] private DungeonGeneratorPostProcessingGrid2D[] _additionalPostProcessingTasks;

    public FixedLevelGraphConfigGrid2D GraphConfig => _graphConfig;
    public DungeonGeneratorPostProcessingGrid2D[] AdditionalPostProcessingTasks => _additionalPostProcessingTasks;
}
