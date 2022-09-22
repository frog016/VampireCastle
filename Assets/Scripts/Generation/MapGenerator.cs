using System;
using System.Linq;
using Edgar.Unity;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(DungeonGeneratorGrid2D))]
public class MapGenerator : MonoBehaviour
{
    [SerializeField] private int _numberLevelsToChangeGenerator;

    public int CurrentLevel { get; private set; }
    public event Action<int> OnLevelPreGenerated;

    private Character _character;
    private DungeonGeneratorGrid2D _generator;
    private ConditionHandler _conditionHandler;
    private GeneratorProvider _provider;

    private void Start()
    {
        _generator = GetComponent<DungeonGeneratorGrid2D>();
        GenerateNextLevel();
    }

    [Inject]
    public void Initialize(Character character, ConditionHandler conditionHandler, GeneratorProvider provider)
    {
        _character = character;
        _conditionHandler = conditionHandler;
        _conditionHandler.OnAllConditionsAreMet(GenerateNextLevel);

        _provider = provider;
    }

    public void GenerateLevel(int level)
    {
        CurrentLevel = level;
        TryChangeGenerator();

        OnLevelPreGenerated?.Invoke(CurrentLevel);
        var generatedLevel = _generator.Generate() as DungeonGeneratorPayloadGrid2D;
        var startPosition = GetStartPosition(generatedLevel.GeneratedLevel);
        MovePlayerInPosition(startPosition);
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

    private void MovePlayerInPosition(Vector2 position)
    {
        _character.transform.position = position;
        _character.GetComponentInChildren<Rigidbody2D>().velocity = Vector2.zero;
    }

    private Vector2 GetStartPosition(DungeonGeneratorLevelGrid2D level)
    {
        return level.RoomInstances.Last().RoomTemplateInstance.GetComponentInChildren<StartPosition>().transform
            .position;
    }
}
