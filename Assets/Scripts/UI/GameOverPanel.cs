using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : PanelBase
{
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Text _moneyText;

    public override void OpenPanel()
    {
        _bestScoreText.text = "Лучший счет: " + Statistic.Instance.BestScore;
        var value = (int)((GenerationManager.Instance.CurrentLevel - 1) * 1.5f);
        GoldenMoneyWallet.Instance.AddMoney(value);
        _moneyText.text = "+ " + value;
        base.OpenPanel();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PauseManager.Continue();
    }
}
