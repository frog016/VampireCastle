using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class FloorInteractiveObjectPostProcessing : InteractiveObjectsPostProcessing
{
    protected override GameObject SpawnInteractiveObject(Tilemap tilemap, GameObject interactiveObject)
    {
        var position = GetValidSpawnPosition(tilemap);
        _map.TryAdd(position);

        var createdObject = _factory.Create(interactiveObject);
        createdObject.transform.position = position;
        return createdObject;
    }

    protected override Vector2 FindSpawnPosition(Tilemap tilemap)
    {
        var positions = _map.GetFreePositions();
        return positions[UnityEngine.Random.Range(0, positions.Length)];
    }

    protected override bool IsPositionValid(Vector2 position)
    {
        return _map.ContainsPosition(position);
    }
}
