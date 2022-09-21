using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Edgar/Post processing/Interactive Objects/HolyWater", fileName = "HolyWaterPostProcessing")]
public class HolyWaterPostProcessing : InteractiveObjectsPostProcessing
{
    protected override GameObject SpawnInteractiveObject(List<Tilemap> tilemaps, GameObject interactiveObject)
    {
        var firstTilemap = tilemaps.First();
        var secondTilemap = tilemaps.Last();
        var position = FindSpawnPosition(firstTilemap);

        while (!IsPositionValid(secondTilemap, position))
            position = FindSpawnPosition(firstTilemap);

        _usedPositions.Add(position.Position);
        return Instantiate(interactiveObject, position.Position, Quaternion.identity);
    }

    protected override WallPosition FindSpawnPosition(Tilemap tilemap)
    {
        var cellSize = tilemap.layoutGrid.cellSize.x; ;
        var bounds = tilemap.cellBounds;
        var position = new Vector2(
            UnityEngine.Random.Range(bounds.xMin, bounds.xMax + (int)cellSize) + cellSize / 2f, 
            UnityEngine.Random.Range(bounds.yMin, bounds.yMax + (int)cellSize) + cellSize / 2f);

        return new WallPosition(Vector2.zero, tilemap.LocalToWorld(position));
    }
}
