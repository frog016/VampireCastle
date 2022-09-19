using UnityEngine.SceneManagement;
using Zenject;

public abstract class PanelBase : TextChanger
{
    private string _startText;
    private MapGenerator _generation;

    protected virtual void Start()
    {
        _startText = _text.text;

        ChangeText(_generation.CurrentLevel);
        _generation.OnLevelGenerated += ChangeText;
        ClosePanel();
    }

    [Inject]
    public void Initialize(MapGenerator generation)
    {
        _generation = generation;
    }

    public virtual void OpenPanel()
    {
        gameObject.SetActive(true);
        PauseManager.Pause();
    }

    public virtual void ClosePanel()
    {
        gameObject.SetActive(false);
        PauseManager.Continue();
    }

    public override void ChangeText(string text)
    {
        base.ChangeText(_startText + text);
    }

    public void ReturnToMenu()
    {
        PauseManager.Continue();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
