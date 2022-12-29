using UnityEngine;
using Zenject;

public class GameResultHandler : MonoBehaviour  //TODO: Refactoring this.
{
    private Timer _timer;
    private DataSaver _dataSaver;

    [Inject]
    public void Initialize(Timer timer)
    {
        _timer = timer;
        _timer.OnTimerTickEvent += GameOver;
    }

    private void Start()
    {
        _dataSaver = FindObjectOfType<DataSaver>();
    }

    private void GameOver()
    {
        if (_timer.CurrentTime > 1e-5)
            return;

        FindObjectOfType<GameOverPanel>(true).OpenPanel();
        _dataSaver?.SaveData();
    }

    private void OnDestroy()
    {
        _timer.OnTimerTickEvent -= GameOver;
    }
}
