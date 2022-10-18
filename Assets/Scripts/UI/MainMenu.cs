using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private Text _moneyText;
        
    private void Start()
    {
        _bestScoreText.text = "Лучший счет: " + Statistic.Instance.BestScore;
        _moneyText.text = GoldenMoneyWallet.Instance.Balance.ToString();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
