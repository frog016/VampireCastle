using System.Collections.Generic;
using System.Linq;
using Edgar.Unity;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Edgar/Post processing/Interactive Objects/Window", fileName = "WindowPostProcessing")]
public class WindowPostProcessing : InteractiveObjectsPostProcessing
{
    [SerializeField] private GameObject _sideWindow;

    protected override WallPosition FindSpawnPosition(Tilemap tilemap)
    {
        var cellSize = tilemap.layoutGrid.cellSize.x; ;
        var bounds = tilemap.cellBounds;

        var position = new Vector2(
            UnityEngine.Random.Range(0, 2) == 0 ? bounds.xMin + cellSize / 2f : bounds.xMax - cellSize / 2f,
            UnityEngine.Random.Range(bounds.yMin + (int)cellSize, bounds.yMax - (int)cellSize) + cellSize / 2f);
        var direction = Vector2.right * Mathf.Sign(tilemap.LocalToWorld(position).x);

        if (UnityEngine.Random.Range(0, 2) == 1)
        {
            position = new Vector2(
                UnityEngine.Random.Range(bounds.xMin + (int)cellSize, bounds.xMax - (int)cellSize) + cellSize / 2f,
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
        var rotation = Quaternion.FromToRotation(Vector3.up, position.WallDirection);
        if (rotation.eulerAngles.z % 180 != 0)
        {
            interactiveObject = _sideWindow;
            rotation.eulerAngles += new Vector3(0, 0, 90);
        }

        var window = Instantiate(interactiveObject, position.Position, rotation);
        Window.Count++;

        return window;
    }
}
