using UnityEngine.SceneManagement;

public class MainMenu : TextChanger
{
    private void Start()
    {
        ChangeText("������ ����: " + Statistic.Instance.BestScore);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
