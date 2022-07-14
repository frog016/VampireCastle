using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class PanelBase : MonoBehaviour
{
    [SerializeField] protected Text _scoreText;

    protected virtual void Start()
    {
        ChangeTextValue(_scoreText);
        GenerationManager.Instance.OnLevelGenerated.AddListener(() => ChangeTextValue(_scoreText));
        ClosePanel();
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

    public void ReturnToMenu()
    {
        PauseManager.Continue();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    protected void ChangeTextValue(Text text)
    {
        text.text = "Текущий счет: " + GenerationManager.Instance.CurrentLevel;
    }
}
