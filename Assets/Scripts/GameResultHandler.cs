using UnityEngine;
using Zenject;

public class GameResultHandler : MonoBehaviour
{
    private Timer _timer;

    [Inject]
    public void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.OnTimerTickEvent += GameOver;
    }

    private void GameOver()
    {
        if (_timer.CurrentTime > 0)
            return;

        FindObjectOfType<GameOverPanel>(true).OpenPanel();
    }

    private void OnDestroy()
    {
        _timer.OnTimerTickEvent -= GameOver;
    }
}
