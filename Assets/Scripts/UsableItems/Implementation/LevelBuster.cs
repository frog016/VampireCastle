using System;
using UnityEngine;

[Serializable]
public class LevelBuster : IUsableItem
{
    [SerializeField] private int _limitLevel;
    [SerializeField] private int _levelBustCount;

    public void Use()
    {
        if (GenerationManager.Instance.CurrentLevel > _limitLevel)
            return;

        GenerationManager.Instance.GenerateLevel(GenerationManager.Instance.CurrentLevel + _levelBustCount);
    }
}
