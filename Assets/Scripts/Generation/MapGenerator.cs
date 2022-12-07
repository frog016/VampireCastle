using System;
using System.Linq;
using Edgar.Unity;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(DungeonGeneratorGrid2D))]
public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int _numberLevelsToChangeGenerator;

    public int NumberLevelsToChangeGenerator => _numberLevelsToChangeGenerator;
    public int CurrentLevel { get; private set; }
    public event Action<int> OnLevelPreGenerated;

    private DungeonGeneratorGrid2D _generator;
    private ConditionHandler _conditionHandler;
    private GeneratorProvider _provider;

    private void Start()
    {
        _generator = GetComponent<DungeonGeneratorGrid2D>();
        GenerateNextLevel();
    }

    [Inject]
    public void Initialize(ConditionHandler conditionHandler, GeneratorProvider provider)
    {
        _conditionHandler = conditionHandler;
        _conditionHandler.OnAllConditionsAreMet(GenerateNextLevel);

        _provider = provider;
    }

    public void GenerateLevel(int level)
    {
        CurrentLevel = level;
        TryChangeGenerator();

        OnLevelPreGenerated?.Invoke(CurrentLevel);
        _generator.Generate();
    }

    public void GenerateNextLevel()
    {
        GenerateLevel(CurrentLevel + 1);
    }

    private void TryChangeGenerator()
    {
        if ((CurrentLevel - 1)% _numberLevelsToChangeGenerator != 0 || CurrentLevel == 0)
            return;

        _provider.ConfigureGenerator(_generator);
    }

    private void OnDisable()
    {
        _provider.UnConfigureGenerator(_generator);
    }
}
