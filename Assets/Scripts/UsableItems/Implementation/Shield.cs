using System.Threading.Tasks;
using UnityEngine;

public class Shield : MonoBehaviour, IUsableItem
{
    [SerializeField] private float _duration;

    private readonly Character _character;

    public Shield(Character character)
    {
        _character = character;
    }

    public void Use()
    {
        ShieldUp(_duration);
    }

    private async void ShieldUp(float duration)
    {
        _character.CanApplyDamage = false;
        await Task.Delay((int)(duration * 1000));
        _character.CanApplyDamage = true;
    }
}
