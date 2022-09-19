using UnityEngine;

public class LevelBuster : MonoBehaviour, IUsableItem
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
