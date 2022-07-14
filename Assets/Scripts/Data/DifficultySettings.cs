using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "Settings/Difficulty", fileName = "DifficultySettings")]
public class DifficultySettings : ScriptableObject
{
    [SerializeField] private List<DifficultyParameter> _parameters;

    public DifficultyParameter GetDifficultyParameter(int level)
    {
        return _parameters.FirstOrDefault(p => p.LevelNumber == level);
    }
}
