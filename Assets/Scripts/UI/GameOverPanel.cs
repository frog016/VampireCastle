using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverPanel : PanelBase // TODO: Refactoring this
{
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private TMP_Text _moneyText;
    [SerializeField] private Statistic _statistic;
    [SerializeField] private MapGenerator _generator;
    [SerializeField] private MoneyWallet _moneyWallet;

    public override void OpenPanel()
    {
        _statistic.BestScore = _generator.CurrentLevel - 1;
        _bestScoreText.text = "Лучший счет: " + _statistic.BestScore;
        var value = (int)((_generator.CurrentLevel - 1) * 1.5f);
        _moneyWallet.AddMoney(value);
        _moneyText.text = "+ " + value + "     <voffset=0.25em> <size=20> <sprite=0> </size> </voffset>";
        base.OpenPanel();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PauseManager.Continue();
    }
}
