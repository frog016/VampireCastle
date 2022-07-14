using System.Collections.Generic;
using System.Linq;
using Edgar.Unity;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class InteractiveObjectsPostProcessing : DungeonGeneratorPostProcessingGrid2D
{
    [SerializeField] private int _itemCount;
    [SerializeField] protected GameObject _itemPrefab;

    public int ItemsCount { get => _itemCount; set => _itemCount = value; }

    protected static HashSet<Vector2> _usedPositions; 

    public override void Run(DungeonGeneratorLevelGrid2D level)
    {
        if (_usedPositions == null)
        {
            var position = level.RoomInstances.Last().RoomTemplateInstance.GetComponentInChildren<StartPosition>()
                .transform.position;
            _usedPositions = new HashSet<Vector2>
            {
                position,
                position + Vector3.up,
                position + Vector3.left
            };
        }

        for (var i = 0; i < _itemCount; i++)
            SpawnInteractiveObject(level.GetSharedTilemaps(), _itemPrefab).transform.SetParent(level.RootGameObject.transform);
    }

    protected abstract GameObject SpawnInteractiveObject(List<Tilemap> tilemap, GameObject interactiveObject);

    protected abstract WallPosition FindSpawnPosition(Tilemap tilemap);

    protected bool IsPositionValid(Tilemap tilemap, WallPosition position)
    {
        var cellPosition = tilemap.WorldToCell(position.Position - position.WallDirection);
        return tilemap.GetTile(cellPosition) == null && !_usedPositions.Contains(position.Position);
    }
}