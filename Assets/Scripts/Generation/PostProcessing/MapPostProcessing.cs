using Assets.Scripts.Pathfind;
using Assets.Scripts.Pathfind.Walker;
using Edgar.Unity;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Edgar/Post processing/Map", fileName = "MapPostProcessing")]
public class MapPostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    private TilemapPathfinder _pathfinder = new TilemapPathfinder(new SlideWalker());

    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        var levelGameObject = level.RootGameObject;
        var map = levelGameObject.GetComponent<Map>();
        map ??= levelGameObject.AddComponent<Map>();
        map.Clear();

        var path = _pathfinder.FindPath(level.GetSharedTilemaps().ToArray());
        map.TakeUpPositions(path);
        map.Center = level.RootGameObject.transform.position;
    }
}
