using System.Linq;
using Edgar.Unity;
using UnityEngine;

[RequireComponent(typeof(DungeonGeneratorGrid2D))]
public class GenerationManager : SingletonObject<GenerationManager>
{
    [SerializeField] private GameObject _player;
    [SerializeField] private DifficultySettings _difficulty;

    public int CurrentLevel { get; set; }

    public int CurrentWindowsCount
    {
        get => _windowsCount;
        set
        {
            _windowsCount = value;
            if (_windowsCount == 0)
                GenerateLevel();
        }
    }

    private int _windowsCount;
    private DifficultyParameter _currentDifficulty;
    private DungeonGeneratorGrid2D _generator;

    protected override void Awake()
    {
        base.Awake();
        _generator = GetComponent<DungeonGeneratorGrid2D>();
    }

    private void Start()
    {
        GenerateLevel();
    }

    public void GenerateLevel()
    {
        CurrentLevel++;
        ChangeGenerationParameters();
        var level = _generator.Generate() as DungeonGeneratorPayloadGrid2D;
        var startPosition = GetStartPosition(level.GeneratedLevel);
        MovePlayerInPosition(startPosition);
    }

    private void MovePlayerInPosition(Vector2 position)
    {
        _player.transform.position = position;
    }

    private Vector2 GetStartPosition(DungeonGeneratorLevelGrid2D level)
    {
        return level.RoomInstances.Last().RoomTemplateInstance.GetComponentInChildren<StartPosition>().transform
            .position;
    }

    private void ChangeGenerationParameters()
    {
        var difficulty = _difficulty.GetDifficultyParameter(CurrentLevel);
        if (difficulty != null)
            _currentDifficulty = difficulty;

        var tasks = _generator.CustomPostProcessTasks.Cast<InteractiveObjectsPostProcessing>().ToList();
        foreach (var task in tasks)
        {
            var type = task.GetType();
            if (type == typeof(WindowPostProcessing))
                task.ItemsCount = _currentDifficulty.WindowsCount;
            else if (type == typeof(HourglassPostProcessing))
                task.ItemsCount = _currentDifficulty.HourglassCount;
            else if (type == typeof(HolyWaterPostProcessing))
                task.ItemsCount = _currentDifficulty.HolyWaterCount;
        }

        _windowsCount = _currentDifficulty.WindowsCount;
        Timer.Instance.TickSpeed = _currentDifficulty.TimerSpeed;
    }
}
