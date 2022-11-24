using System.Linq;
using Edgar.Unity;
using UnityEngine;
using Zenject;

[CreateAssetMenu(menuName = "Edgar/Post processing/Player", fileName = "PlayerPostProcessing")]
public class PlayerPostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    private Character _character;

    [Inject]
    public void Initialize(Character character)
    {
        _character = character;
    }

    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        var startPosition = GetStartPosition(level);
        MovePlayerInPosition(startPosition);
    }

    private void MovePlayerInPosition(Vector2 position)
    {
        _character.transform.position = position;
        _character.GetComponentInChildren<Rigidbody2D>().velocity = Vector2.zero;
    }

    private static Vector2 GetStartPosition(DungeonGeneratorLevelGrid2D level)
    {
        return level.RoomInstances
            .Last().RoomTemplateInstance
            .GetComponentInChildren<StartPosition>()
            .transform.position;
    }
}
