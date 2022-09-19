using System;
using System.Linq;
using Edgar.Unity;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(DungeonGeneratorGrid2D))]
public class MapGenerator : MonoBehaviour
{
    [SerializeField] private DifficultySettings _difficulty;

    public int CurrentLevel { get; private set; }
    public event Action<int> OnLevelGenerated;

    private Timer _timer;
    private Character _character;
    private DungeonGeneratorGrid2D _generator;
    private ConditionHandler _conditionHandler;

    private void Start()
    {
        _generator = GetComponent<DungeonGeneratorGrid2D>();
        GenerateNextLevel();
    }

    [Inject]
    public void Initialize(Timer timer, Character character, ConditionHandler conditionHandler)
    {
        _timer = timer;
        _character = character;
        _conditionHandler = conditionHandler;
        _conditionHandler.OnAllConditionsAreMet(GenerateNextLevel);
    }

    public void GenerateLevel(int level)
    {
        CurrentLevel = level;
        ChangeGenerationParameters();

        var generatedLevel = _generator.Generate() as DungeonGeneratorPayloadGrid2D;
        var startPosition = GetStartPosition(generatedLevel.GeneratedLevel);
        MovePlayerInPosition(startPosition);

        OnLevelGenerated?.Invoke(CurrentLevel);
    }

    public void GenerateNextLevel()
    {
        GenerateLevel(CurrentLevel + 1);
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

    private void ChangeGenerationParameters()
    {
        var currentDifficulty = _difficulty.GetDifficultyParameter(CurrentLevel);
        if (currentDifficulty == null)
            return;

        var tasks = _generator.CustomPostProcessTasks.Cast<InteractiveObjectsPostProcessing>().ToList();
        foreach (var task in tasks)
        {
            var type = task.GetType();
            if (type == typeof(WindowPostProcessing))
                task.ItemsCount = currentDifficulty.WindowsCount;
            else if (type == typeof(HourglassPostProcessing))
                task.ItemsCount = currentDifficulty.HourglassCount;
            else if (type == typeof(HolyWaterPostProcessing))
                task.ItemsCount = currentDifficulty.HolyWaterCount;
        }

        _timer.TickSpeed = currentDifficulty.TimerSpeed;
    }
}
