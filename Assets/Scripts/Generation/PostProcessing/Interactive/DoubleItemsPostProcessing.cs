using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Edgar/Post processing/Interactive Objects/DoubleItemsPostProcessing", fileName = "DoubleItemsPostProcessing")]
public class DoubleItemsPostProcessing : InteractiveObjectsPostProcessing
{
    [SerializeField] private GameObject _otherInteractiveObject;

    protected override GameObject[] SpawnInteractiveObjects(Tilemap tilemap, GameObject interactiveObject)
    {
        var first = SpawnObject(tilemap, interactiveObject);
        var second = SpawnObject(tilemap, _otherInteractiveObject);
        LinkObjects(first, second);

        return new GameObject[] { first, second };
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

    private GameObject SpawnObject(Tilemap tilemap, GameObject interactiveObject)
    {
        var position = GetValidSpawnPosition(tilemap);
        _map.TryAdd(position);

        var createdObject = _factory.Create(interactiveObject);
        createdObject.transform.position = position;

        return createdObject;
    }

    private static void LinkObjects(GameObject first, GameObject second)
    {
        var firstDependenteable = first.GetComponent<IDependenteable>();
        var secondDependenteable = second.GetComponent<IDependenteable>();

        firstDependenteable.InitializeDependency(secondDependenteable);
        secondDependenteable.InitializeDependency(firstDependenteable);
    }
}
