using UnityEngine;

public class PausePanel : PanelBase
{
    [SerializeField] private TextField _currentScore;
    [SerializeField] private MapGenerator _generator;

    private void OnEnable()
    {
        _currentScore.ChangeText((_generator.CurrentLevel - 1).ToString());
        _generator.OnLevelPreGenerated += ChangeIntToText;
    }

    private void ChangeIntToText(int value)
    {
        _currentScore.ChangeText(value.ToString());
    }

    private void OnDisable() => _generator.OnLevelPreGenerated -= ChangeIntToText;
}
