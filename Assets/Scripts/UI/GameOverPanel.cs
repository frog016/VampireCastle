using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverPanel : PanelBase
{
    [SerializeField] private Text _bestScoreText;
    [SerializeField] private TMP_Text _moneyText;

    public override void OpenPanel()
    {
        _bestScoreText.text = "Лучший счет: " + Statistic.Instance.BestScore;
        //var value = (int)((GenerationManager.Instance.CurrentLevel - 1) * 1.5f);  //TODO: исправить и убрать комменты
        //GoldenMoneyWallet.Instance.AddMoney(value);
        //_moneyText.text = "+ " + value + "     <voffset=0.25em> <size=20> <sprite=0> </size> </voffset>";
        base.OpenPanel();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PauseManager.Continue();
    }
}
