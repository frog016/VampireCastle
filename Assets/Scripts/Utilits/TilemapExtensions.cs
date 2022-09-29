using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class TilemapExtensions
{
    public static IEnumerable<Vector3> GetPositionsWorld(this Tilemap tilemap)
    {
        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {
            var localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            if (tilemap.HasTile(localPlace))
                yield return tilemap.CellToWorld(localPlace);
        }
    }

    public static Vector2 GetPointProjection(this BoundsInt bounds, Vector2 point)
    {
        var left = new Vector2(bounds.xMin, point.y);
        var right = new Vector2(bounds.xMax, point.y);
        var bottom = new Vector2(point.x, bounds.yMin);
        var top = new Vector2(point.x, bounds.yMax);

        return new Vector2[] { left, top, right, bottom }.MinElement(position => (point - position).magnitude);
    }
}
