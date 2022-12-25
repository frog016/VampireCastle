using UnityEngine;

public class DifficultyChanger : MonoBehaviour
{
    [SerializeField] private DifficultySettings _settings;

    private MapGenerator _generator;

    private void Awake()
    {
        _generator = GetComponent<MapGenerator>();
        _generator.OnLevelPreGenerated += ChangeDifficultParameters;
    }

    private void ChangeDifficultParameters(int level)
    {
        _settings.TryConfigureAll(level);
    }

    private void OnDisable()
    {
        if (_generator != null)
            _generator.OnLevelPreGenerated -= ChangeDifficultParameters;
    }
}
