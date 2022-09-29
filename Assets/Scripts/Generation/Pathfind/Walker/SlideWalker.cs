using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Pathfind.Walker
{
    public class SlideWalker : IWalker<Vector2, Tilemap>
    {
        public IEnumerable<Vector2> Walk(Vector2 start, Vector2 direction, Tilemap map)
        {
            var step = map.layoutGrid.cellSize.x;
            
            var nextPoint = start + direction * step;
            while (!map.HasTile(map.WorldToCell(nextPoint)))
            {
                yield return nextPoint;
                nextPoint += direction * step;
            }
        }
    }
}