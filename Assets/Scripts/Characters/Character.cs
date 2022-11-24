using UnityEngine;

public class Character : MonoBehaviour
{
    public bool CanApplyDamage { get; set; }

    private Timer _timer;

    private void Awake()
    {
        _timer = FindObjectOfType<Timer>();
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
