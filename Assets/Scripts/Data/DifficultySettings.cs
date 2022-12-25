using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Difficulty", fileName = "DifficultySettings")]
public class DifficultySettings : ScriptableObject
{
    [SerializeField] private List<DifficultyRecord> _settings;

    public void TryConfigureAll(int level)
    {
        foreach (var difficultyRecord in _settings)
            difficultyRecord.TryConfigureScriptableObject(level);
    }

    [Serializable]
    private class DifficultyRecord
    {
        [SerializeField] private ScriptableObject _configurable;
        [SerializeField] private DifficultyParameter[] _difficultyParameters;

        public void TryConfigureScriptableObject(int level)
        {
            var data = _difficultyParameters
                .TakeWhile(p => level >= p.LevelNumber)
                .Last().ParameterValue;
            //var data = _difficultyParameters.FirstOrDefault(p => p.LevelNumber == level)?.ParameterValue;
            //if (!data.HasValue)
            //    return;

            (_configurable as IConfigurable<float>)?.Configure(data);
        }

        [Serializable]
        private class DifficultyParameter
        {
            [SerializeField] private int _levelNumber;
            [SerializeField] private float _parameterValue;

            public int LevelNumber => _levelNumber;
            public float ParameterValue => _parameterValue;
        }
    }
}
