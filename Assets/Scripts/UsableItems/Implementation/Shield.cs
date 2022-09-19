using System;
using System.Threading.Tasks;
using UnityEngine;

public class Shield : IUsableItem
{
    private float _duration;
    private readonly Character _character;

    public Shield(Character character, Parameters parameters)
    {
        _character = character;
        _duration = parameters.Duration;
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

    [Serializable]
    public class Parameters
    {
        [SerializeField] private float _duration;

        public float Duration => _duration;
    }
}
