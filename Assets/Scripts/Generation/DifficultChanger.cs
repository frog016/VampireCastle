using System.Linq;
using Edgar.Unity;
using UnityEngine;
using Zenject;

public class DifficultChanger : MonoBehaviour
{
    [SerializeField] private DifficultySettings _settings;

    private MapGenerator _generator;
    private Timer _timer;

    private void Awake()
    {
        _generator = GetComponent<MapGenerator>();
        _generator.OnLevelPreGenerated += ChangeDifficultParameters;
    }

    [Inject]
    public void Initialize(Timer timer)
    {
        _timer = timer;
    }

    private void ChangeDifficultParameters(int level)
    {
        var currentDifficulty = _settings.GetDifficultyParameter(level);
        if (currentDifficulty == null)
            return;

        var tasks = _generator
            .GetComponent<DungeonGeneratorGrid2D>().CustomPostProcessTasks
            .Where(task => task is InteractiveObjectsPostProcessing)
            .Cast<InteractiveObjectsPostProcessing>()
            .ToList();

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

    private void OnDestroy()
    {
        if (_generator != null)
            _generator.OnLevelPreGenerated -= ChangeDifficultParameters;
    }
}
