using UnityEngine.SceneManagement;

public class MainMenu : TextChanger
{
    private void Start()
    {
        ChangeText("Лучший счет: " + Statistic.Instance.BestScore);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
