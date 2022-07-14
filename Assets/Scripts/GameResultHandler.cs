using UnityEngine;

public class GameResultHandler : MonoBehaviour
{
    private void Start()
    {
        Timer.Instance.OnTimerTickEvent.AddListener(GameOver);
    }

    private void GameOver()
    {
        if (Timer.Instance.CurrentTime > 0)
            return;

        FindObjectOfType<GameOverPanel>(true).OpenPanel();
    }
}
