using System.Linq;
using Edgar.Unity;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Edgar/Post processing/Player", fileName = "PlayerPostProcessing")]
public class PlayerPostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    private CharacterHealth characterHealth;

    [Inject]
    public void Initialize(CharacterHealth characterHealth)
    {
        this.characterHealth = characterHealth;
    }

    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        var startPosition = GetStartPosition(level);
        MovePlayerInPosition(startPosition);
    }

    private void MovePlayerInPosition(Vector2 position)
    {
        characterHealth.transform.position = position;
        characterHealth.GetComponentInChildren<Rigidbody2D>().velocity = Vector2.zero;
    }

    private static Vector2 GetStartPosition(DungeonGeneratorLevelGrid2D level)
    {
        return level.RoomInstances
            .Last().RoomTemplateInstance
            .GetComponentInChildren<StartPosition>()
            .transform.position;
    }
}
