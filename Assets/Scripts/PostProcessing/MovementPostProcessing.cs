using System.Linq;
using Edgar.Unity;
using UnityEngine;

[CreateAssetMenu(menuName = "Edgar/Post processing/Movement", fileName = "MovementPostProcessing")]
public class MovementPostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        FindObjectOfType<CharacterController>().GetComponent<Movement>().Initialize(level.GetSharedTilemaps().Last());
    }
}