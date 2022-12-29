using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : PanelBase // TODO: Refactoring this
{
    [SerializeField] private TextField _finaleScore;
    [SerializeField] private TextField _bestScore;
    [SerializeField] private TextField _money;

    [Header("Required data")]
    [SerializeField] private MapGenerator _generator;
    [SerializeField] private Statistic _statistic;
    [SerializeField] private MoneyWallet _moneyWallet;

    private float _initialMoneyValue;

    private void Awake()
    {
        _initialMoneyValue = _moneyWallet.Balance.Value;
    }

    public override void OpenPanel()
    {
        var currentScore = _generator.CurrentLevel - 1;
        _statistic.BestScore.Value = currentScore;
        _finaleScore.ChangeText(currentScore.ToString());
        _bestScore.ChangeText(_statistic.BestScore.Value.ToString());

        var value = (int)(_moneyWallet.Balance.Value - _initialMoneyValue);
        _money.ChangeText(value.ToString());
        base.OpenPanel();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PauseManager.Continue();
    }
}
