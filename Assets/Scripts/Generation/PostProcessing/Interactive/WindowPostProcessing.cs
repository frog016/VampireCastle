using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Edgar/Post processing/Interactive Objects/Window", fileName = "WindowPostProcessing")]
public class WindowPostProcessing : InteractiveObjectsPostProcessing
{
    private Vector2 _direction;

    protected override GameObject SpawnInteractiveObject(Tilemap tilemap, GameObject interactiveObject)
    {
        var position = GetValidSpawnPosition(tilemap);
        _map.TryAdd(position - _direction);

        var createdObject = _factory.Create(interactiveObject);
        createdObject.transform.position = position;
        return createdObject;
    }

    protected override Vector2 FindSpawnPosition(Tilemap tilemap)
    {
        var positions = _map.GetFreePositions();
        var position = positions[UnityEngine.Random.Range(0, positions.Length)];
        var projection = (Vector2)tilemap.LocalToWorld(tilemap.cellBounds.GetPointProjection(tilemap.WorldToLocal(position)));

        var cellSize = tilemap.layoutGrid.cellSize.x;
        _direction = (projection - position).normalized * cellSize;

        projection -= _direction / 2f;
        return projection;
    }

    protected override bool IsPositionValid(Vector2 position)
    {
        var newPosition = position - _direction;
        return _map.ContainsPosition(newPosition) && _map.IsEmpty(newPosition);
    }
}
