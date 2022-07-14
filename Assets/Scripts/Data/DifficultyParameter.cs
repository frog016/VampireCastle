using System;
using UnityEngine;

[Serializable]
public class DifficultyParameter
{
    [SerializeField] private int _levelNumber;
    [SerializeField] private int _windowsCount;
    [SerializeField] private int _hourglassCount;
    [SerializeField] private int _holyWaterCount;
    [SerializeField] private float _timerSpeed;

    public int LevelNumber => _levelNumber;
    public int WindowsCount => _windowsCount;
    public int HourglassCount => _hourglassCount;
    public int HolyWaterCount => _holyWaterCount;
    public float TimerSpeed => _timerSpeed;
}
