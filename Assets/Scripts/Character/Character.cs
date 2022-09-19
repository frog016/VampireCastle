using UnityEngine;

public class Character : MonoBehaviour
{
    public bool CanApplyDamage { get; set; }

    private void Awake()
    {
        CanApplyDamage = true;
    }

    public void ApplyDamage(float damage)
    {
        if (!CanApplyDamage)
            return;

        Timer.Instance.CurrentTime -= damage;
    }

    public void ApplyHealth(float health)
    {
        Timer.Instance.CurrentTime += health;
    }
}
