using System.Collections.Generic;
using System.Linq;
using Edgar.Unity;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Edgar/Post processing/Interactive Objects", fileName = "InteractiveObjectsPostProcessing")]
public class InteractiveObjectsPostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    [SerializeField] private int _windowsCount;
    [SerializeField] private GameObject _windowPrefab;

    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        var tilemap = level.GetSharedTilemaps().Last();

        var hashset = new HashSet<Vector2>();
        for (var i = 0; i < _windowsCount; i++)
           SpawnInteractiveObject(tilemap, _windowPrefab, hashset).transform.SetParent(level.RootGameObject.transform);
    }

    private GameObject SpawnInteractiveObject(Tilemap tilemap, GameObject interactiveObject, HashSet<Vector2> usedPositions)
    {
        var position = FindSpawnPosition(tilemap);

        while (!IsPositionValid(tilemap, position) || usedPositions.Contains(position.Position))
            position = FindSpawnPosition(tilemap);

        usedPositions.Add(position.Position);
        var rotation = Mathf.Abs(position.Position.x - tilemap.cellBounds.xMin) < 1e-4 ||
                       Mathf.Abs(position.Position.x - tilemap.cellBounds.xMax) < 1e-4
            ? Quaternion.Euler(0, 0, Mathf.Sign(position.Position.x) * 90) : Quaternion.identity;
        return Instantiate(interactiveObject, position.Position, rotation);
    }

    private bool IsPositionValid(Tilemap tilemap,WallPosition position)
    {
        var cellPosition = tilemap.WorldToCell(position.Position - position.WallDirection);
        return tilemap.GetTile(cellPosition) == null;
    }

    private WallPosition FindSpawnPosition(Tilemap tilemap)
    {
        var cellSize = 1;
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
}