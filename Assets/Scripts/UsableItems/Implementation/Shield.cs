using System;
using System.Threading.Tasks;
using UnityEngine;

public class Shield : IUsableItem
{
    private float _duration;
    private readonly CharacterHealth characterHealth;

    public Shield(CharacterHealth characterHealth, Parameters parameters)
    {
        this.characterHealth = characterHealth;
        _duration = parameters.Duration;
    }

    public void Use()
    {
        //ShieldUp(_duration);
    }

    //private async void ShieldUp(float duration)
    //{
    //    characterHealth.CanApplyDamage = false;
    //    await Task.Delay((int)(duration * 1000));
    //    characterHealth.CanApplyDamage = true;
    //}

    [Serializable]
    public class Parameters
    {
        [SerializeField] private float _duration;

        public float Duration => _duration;
    }
}
