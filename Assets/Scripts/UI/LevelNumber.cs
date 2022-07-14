using UnityEngine;
using UnityEngine.UI;

public class LevelNumber : MonoBehaviour
{
    private Text _levelNumberText;

    private void Awake()
    {
        _levelNumberText = GetComponentInChildren<Text>();
    }

    private void Start()
    {
        _levelNumberText.text = GenerationManager.Instance.CurrentLevel.ToString();
        GenerationManager.Instance.OnLevelGenerated.AddListener(() => _levelNumberText.text = GenerationManager.Instance.CurrentLevel.ToString());
    }
}
