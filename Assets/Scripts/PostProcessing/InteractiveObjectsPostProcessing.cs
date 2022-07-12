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

        for (var i = 0; i < _windowsCount; i++)
            SpawnInteractiveObject(tilemap, _windowPrefab);
    }

    private void SpawnInteractiveObject(Tilemap tilemap, GameObject interactiveObject)
    {
        var position = FindSpawnPosition(tilemap);

        while (!IsPositionValid(position))
            position = FindSpawnPosition(tilemap);

        var rotation = Mathf.Abs(position.Position.x - tilemap.cellBounds.xMin) < 1e-4 ||
                       Mathf.Abs(position.Position.x - tilemap.cellBounds.xMax) < 1e-4
            ? Quaternion.Euler(0, 0, Mathf.Sign(position.Position.x) * 90) : Quaternion.identity;
        Instantiate(interactiveObject, position.Position, rotation);
    }

    private bool IsPositionValid(WallPosition position)
    {
        var a = Physics2D.OverlapPointAll(position.Position);
        Debug.Log(a.Length);
        return Physics2D.OverlapPoint(position.Position - position.WallDirection) == null;
    }

    private WallPosition FindSpawnPosition(Tilemap tilemap)
    {
        var cellSize = 1;
        var bounds = tilemap.cellBounds;

        var position = new Vector2(
            UnityEngine.Random.Range(0, 2) == 0 ? bounds.xMin + cellSize / 2f : bounds.xMax - cellSize / 2f,
            UnityEngine.Random.Range(bounds.yMin + cellSize, bounds.yMax - cellSize) + cellSize / 2f);
        var direction = Vector2.right * Mathf.Sign(position.x);

        if (UnityEngine.Random.Range(0, 2) == 1)
        {
            position = new Vector2(
                UnityEngine.Random.Range(bounds.xMin + cellSize, bounds.xMax - cellSize) + cellSize / 2f,
                UnityEngine.Random.Range(0, 2) == 0 ? bounds.yMin + cellSize / 2f : bounds.yMax - cellSize / 2f);
            direction = Vector2.up * Mathf.Sign(position.y);
        }

        return new WallPosition(direction, tilemap.LocalToWorld(position));
    }
}