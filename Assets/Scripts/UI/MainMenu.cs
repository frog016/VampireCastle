using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : TextChanger
{
    [SerializeField] private Statistic _statistic;
    [SerializeField] private Text _moneyText;
    [SerializeField] private MoneyWallet _moneyWallet;

    private void Start()
    {
        ChangeText("Лучший счет: " + _statistic.BestScore);
        _moneyText.text = _moneyWallet.Balance.ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
