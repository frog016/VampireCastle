using System.Collections.Generic;
using Edgar.Unity;
using UnityEngine;

[CreateAssetMenu(menuName = "Generation/GenerationData", fileName = "GenerationData")]
public class GenerationData : ScriptableObject
{
    [SerializeField] private FixedLevelGraphConfigGrid2D _graphConfig;
    [SerializeField] private List<DungeonGeneratorPostProcessingGrid2D> _additionalPostProcessingTasks = new List<DungeonGeneratorPostProcessingGrid2D>();

    public FixedLevelGraphConfigGrid2D GraphConfig => _graphConfig;
    public DungeonGeneratorPostProcessingGrid2D[] AdditionalPostProcessingTasks => _additionalPostProcessingTasks.ToArray();
}
