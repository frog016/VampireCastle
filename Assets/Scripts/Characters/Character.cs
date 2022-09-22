using UnityEngine;
using Zenject;

public class Character : MonoBehaviour
{
    public bool CanApplyDamage { get; set; }

    private Timer _timer;

    [Inject]
    public void Initialize(Timer timer)
    {
        _timer = timer;
        CanApplyDamage = true;
    }

    public void ApplyDamage(float damage)
    {
        if (!CanApplyDamage)
            return;

        _timer.CurrentTime -= damage;
    }

    public void ApplyHealth(float health)
    {
        _timer.CurrentTime += health;
    }
}
