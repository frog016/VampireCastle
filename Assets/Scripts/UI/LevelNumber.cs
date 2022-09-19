using UnityEngine.UI;
using Zenject;

public class LevelNumber : TextChanger
{
    private MapGenerator _generation;

    private void Start()
    {
        _text = GetComponentInChildren<Text>();

        ChangeText(_generation.CurrentLevel);
        _generation.OnLevelGenerated += ChangeText;
    }

    [Inject]
    public void Initialize(MapGenerator generation)
    {
        _generation = generation;
    }

    private void OnDestroy()
    {
        _generation.OnLevelGenerated -= ChangeText;
    }
}
