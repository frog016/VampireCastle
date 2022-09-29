using System.Linq;
using Edgar.Unity;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

public abstract class InteractiveObjectsPostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    [SerializeField] private int _itemCount;
    [SerializeField] protected GameObject _itemPrefab;

    public int ItemsCount { get => _itemCount; set => _itemCount = value; }

    protected Map _map;
    protected IFactory<GameObject> _factory;

    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        _map = level.RootGameObject.GetComponent<Map>();

        for (var i = 0; i < _itemCount; i++)
            SpawnInteractiveObject(level.GetSharedTilemaps().Last(), _itemPrefab).transform.SetParent(level.RootGameObject.transform);
    }

    [Inject]
    public void Initialize(IFactory<GameObject> factory)
    {
        _factory = factory;
    }

    protected Vector2 GetValidSpawnPosition(Tilemap tilemap)
    {
        var position = FindSpawnPosition(tilemap);
        while (!IsPositionValid(position))
            position = FindSpawnPosition(tilemap);

        return position;
    }

    protected abstract Vector2 FindSpawnPosition(Tilemap tilemap);

    protected abstract GameObject SpawnInteractiveObject(Tilemap tilemap, GameObject interactiveObject);

    protected abstract bool IsPositionValid(Vector2 position);
}