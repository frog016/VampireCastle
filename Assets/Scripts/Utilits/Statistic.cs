using UnityEngine;

[CreateAssetMenu(menuName = "Statistic", fileName = "Statistic")]
public class Statistic : SavableScriptableObject
{
    [SerializeField] private int _bestScore;

    public readonly ObservableVariable<int> BestScore = new ObservableVariable<int>();

    private void OnEnable()
    {
        BestScore.ChangeValidator(newValue => BestScore.Value < newValue);
    }

    private void OnValidate()
    {
        BestScore.ChangeValidator(newValue => BestScore.Value < newValue);
        BestScore.Value = _bestScore;
    }

    public override void OnAfterDeserialize()
    {
        BestScore.Value = _bestScore;
    }
}
