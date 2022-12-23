using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Text _moneyText;
    [SerializeField] private Statistic _statistic;
    [SerializeField] private MoneyWallet _moneyWallet;

    private void Start()
    {
        _statistic.BestScore.ValueChangedEvent += ChangeScoreText;
        ChangeScoreText(_statistic.BestScore.Value);

        _moneyWallet.OnBalanceUpdatedEvent += ChangeMoneyText;
        ChangeMoneyText(_moneyWallet.Balance);
    }

    private void ChangeScoreText(int value)
    {
        ChangeText(_bestScoreText, "Лучший счет: " + value);
    }

    private void ChangeMoneyText(float value)
    {
        ChangeText(_moneyText, value.ToString());
    }

    private static void ChangeText(Text uiText, string value)
    {
        uiText.text = value;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void OnDisable()
    {
        _statistic.BestScore.ValueChangedEvent -= ChangeScoreText;
        _moneyWallet.OnBalanceUpdatedEvent -= ChangeMoneyText;
    }
}
