using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Edgar/Post processing/Interactive Objects/Window", fileName = "WindowPostProcessing")]
public class WindowPostProcessing : InteractiveObjectsPostProcessing
{
    protected override WallPosition FindSpawnPosition(Tilemap tilemap)
    {
        var cellSize = tilemap.layoutGrid.cellSize.x; ;
        var bounds = tilemap.cellBounds;

        var position = new Vector2(
            UnityEngine.Random.Range(0, 2) == 0 ? bounds.xMin + cellSize / 2f : bounds.xMax - cellSize / 2f,
            UnityEngine.Random.Range(bounds.yMin + cellSize, bounds.yMax - cellSize) + cellSize / 2f);
        var direction = Vector2.right * Mathf.Sign(tilemap.LocalToWorld(position).x);

        if (UnityEngine.Random.Range(0, 2) == 1)
        {
            position = new Vector2(
                UnityEngine.Random.Range(bounds.xMin + cellSize, bounds.xMax - cellSize) + cellSize / 2f,
                UnityEngine.Random.Range(0, 2) == 0 ? bounds.yMin + cellSize / 2f : bounds.yMax - cellSize / 2f);
            direction = Vector2.up * Mathf.Sign(tilemap.LocalToWorld(position).y);
        }

        return new WallPosition(direction, tilemap.LocalToWorld(position));
    }

    protected override GameObject SpawnInteractiveObject(List<Tilemap> tilemaps, GameObject interactiveObject)
    {
        var tilemap = tilemaps.Last();
        var position = FindSpawnPosition(tilemap);

        while (!IsPositionValid(tilemap, position))
            position = FindSpawnPosition(tilemap);

        _usedPositions.Add(position.Position);
        var rotation = Mathf.Abs(position.Position.x - tilemap.cellBounds.xMin) < 1e-4 ||
                       Mathf.Abs(position.Position.x - tilemap.cellBounds.xMax) < 1e-4
            ? Quaternion.Euler(0, 0, Mathf.Sign(position.Position.x) * 90) : Quaternion.identity;
        return Instantiate(interactiveObject, position.Position, rotation);
    }
}
