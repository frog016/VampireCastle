using System;
using UnityEngine;

public class LevelBuster : IUsableItem
{
    private int _limitLevel;
    private int _levelBustCount;
    private readonly MapGenerator _generation;

    public LevelBuster(MapGenerator generation, Parameters parameters)
    {
        _limitLevel = parameters.LimitLevel;
        _levelBustCount = parameters.LevelBustCount;
        _generation = generation;
    }

    public void Use()
    {
        if (_generation.CurrentLevel > _limitLevel)
            return;

        _generation.GenerateLevel(_generation.CurrentLevel + _levelBustCount);
    }

    [Serializable]
    public class Parameters
    {
        [SerializeField] private int _limitLevel;
        [SerializeField] private int _levelBustCount;

        public int LimitLevel => _limitLevel;
        public int LevelBustCount => _levelBustCount;
    }
}
