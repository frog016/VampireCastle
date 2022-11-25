using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Edgar/Post processing/Interactive Objects/FloorInteractiveObject", fileName = "FloorInteractiveObject")]
public class FloorInteractiveObjectPostProcessing : InteractiveObjectsPostProcessing
{
    protected override GameObject[] SpawnInteractiveObjects(Tilemap tilemap, GameObject interactiveObject)
    {
        var position = GetValidSpawnPosition(tilemap);
        _map.TryAdd(position);

        var createdObject = _factory.Create(interactiveObject);
        createdObject.transform.position = position;

        return new GameObject[] { createdObject };
    }

    protected override Vector2 FindSpawnPosition(Tilemap tilemap)
    {
        var positions = _map.GetFreePositions();
        return positions[UnityEngine.Random.Range(0, positions.Length)];
    }

    protected override bool IsPositionValid(Vector2 position)
    {
        return _map.ContainsPosition(position) && _map.IsEmpty(position);
    }
}
