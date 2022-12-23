using UnityEngine;

[CreateAssetMenu(menuName = "Statistic", fileName = "Statistic")]
public class Statistic : SavableScriptableObject
{
    [SerializeField] private int _bestScore;

    public ObservableVariable<int> BestScore = new ObservableVariable<int>();

    private void OnValidate()
    {
        BestScore.Value = _bestScore;
    }
}
