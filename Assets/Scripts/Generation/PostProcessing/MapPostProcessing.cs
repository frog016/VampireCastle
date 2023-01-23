using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Pathfind;
using Assets.Scripts.Pathfind.Walker;
using Edgar.Unity;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Edgar/Post processing/Map", fileName = "MapPostProcessing")]
public class MapPostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        var levelGameObject = level.RootGameObject;
        var map = levelGameObject.GetComponent<Map>();
        map ??= levelGameObject.AddComponent<Map>();
        map.Clear();

        var positions = GetFreePositions(level.GetSharedTilemaps().ToArray());
        map.TakeUpPositions(positions);
        map.Center = level.RootGameObject.transform.position;
    }

    private Vector2[] GetFreePositions(Tilemap[] tilemaps)
    {
        var floor = tilemaps.First();
        var wall = tilemaps.Last();
        var result = new List<Vector2>();
        foreach (var position in floor.cellBounds.allPositionsWithin)
        {
            var worldPosition = floor.GetCellCenterWorld(position);
            var colliders = Physics2D.OverlapBoxAll(worldPosition, Vector2.one, 0);
            if (colliders.Length == 0 && wall.GetTile(position) == null)
                result.Add(worldPosition);
        }

        return result.ToArray();
    }
}
