using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : PanelBase
{
    [SerializeField] private Text _bestScoreText;

    public override void OpenPanel()
    {
        _bestScoreText.text = "Лучший счет: " + Statistic.Instance.BestScore;
        base.OpenPanel();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PauseManager.Continue();
    }
}
