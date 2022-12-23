using UnityEngine;
using Zenject;

public class CharacterHealth : MonoBehaviour
{
    private Timer _timer;

    [Inject]
    public void Initialize(Timer timer)
    {
        _timer = timer;
    }

    public void ChangeHealth(float damage)
    {
        _timer.CurrentTime += damage;
    }
}
