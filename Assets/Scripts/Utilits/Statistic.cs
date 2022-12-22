using UnityEngine;

[CreateAssetMenu(menuName = "Statistic", fileName = "Statistic")]
public class Statistic : SavableScriptableObject
{
    [SerializeField] private int _bestScore;

    public int BestScore { get => _bestScore; set => _bestScore = value; }
}
