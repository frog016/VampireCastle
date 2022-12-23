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

    private float _initialMoneyValue;

    private void Awake()
    {
        _initialMoneyValue = _moneyWallet.Balance;
    }

    public override void OpenPanel()
    {
        if (_generator.CurrentLevel - 1 > _statistic.BestScore.Value)
            _statistic.BestScore.Value = _generator.CurrentLevel - 1;
        _bestScoreText.text = "Лучший счет: " + _statistic.BestScore.Value;
        var value = (int)(_moneyWallet.Balance - _initialMoneyValue);
        _moneyText.text = "+ " + value + "     <voffset=0.25em> <size=20> <sprite=0> </size> </voffset>";
        base.OpenPanel();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PauseManager.Continue();
    }
}
