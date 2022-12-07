using System.Collections.Generic;
using System.Linq;
using Edgar.Unity;
using UnityEngine;

[CreateAssetMenu(menuName = "Generation/GeneratorProvider", fileName = "GeneratorProvider")]
public class GeneratorProvider : ScriptableObject, IGeneratorProvider<DungeonGeneratorGrid2D, GenerationData>
{
    [SerializeField] private GenerationData[] _mapDataPool;

    private GenerationData _currentData;
    private readonly HashSet<GenerationData> _usedMaps = new HashSet<GenerationData>();

    public void ConfigureGenerator(DungeonGeneratorGrid2D generator)
    {
        UnConfigureGenerator(generator);
        _currentData = GetGenerationData();

        generator.FixedLevelGraphConfig = _currentData.GraphConfig;
        generator.CustomPostProcessTasks.AddRange(_currentData.AdditionalPostProcessingTasks);
    }

    public void UnConfigureGenerator(DungeonGeneratorGrid2D generator)
    {
        if (_currentData == null || _currentData.AdditionalPostProcessingTasks.Length == 0)
            return;

        var length = generator.CustomPostProcessTasks.Count;
        generator.CustomPostProcessTasks.RemoveAt(length - _currentData.AdditionalPostProcessingTasks.Length);
        _currentData = null;
    }

    public GenerationData GetGenerationData()
    {
        var notUsedData = GetNotUsedData();
        if (notUsedData.Length == 0)
        {
            _usedMaps.Clear();
            notUsedData = GetNotUsedData();
        }

        var data = notUsedData[Random.Range(0, notUsedData.Length)];
        _usedMaps.Add(data);

        return data;
    }

    private GenerationData[] GetNotUsedData()
    {
        return _mapDataPool
            .Where(data => !_usedMaps.Contains(data))
            .ToArray();
    }
}
