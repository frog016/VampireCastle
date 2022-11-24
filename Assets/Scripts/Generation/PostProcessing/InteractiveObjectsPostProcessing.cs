using System.Linq;
using Edgar.Unity;
using UnityEngine;
using UnityEngine.Tilemaps;
using Zenject;

public abstract class InteractiveObjectsPostProcessing : DungeonGeneratorPostProcessingGrid2D, IConfigurable<float>
{
    [SerializeField] private int _objectsCount;
    [SerializeField] protected GameObject _objectPrefab;

    protected Map _map;
    protected IFactory<GameObject> _factory;

    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        _map = level.RootGameObject.GetComponent<Map>();

        for (var i = 0; i < _objectsCount; i++)
            SpawnInteractiveObject(level.GetSharedTilemaps().Last(), _objectPrefab).transform.SetParent(level.RootGameObject.transform);
    }

    [Inject]
    public void Initialize(IFactory<GameObject> factory)
    {
        _factory = factory;
    }

    public void Configure(float value)
    {
        _objectsCount = (int)value;
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