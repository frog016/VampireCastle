using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts.Pathfind.Walker
{
    public class SlideWalker : IWalker
    {
        private readonly Tilemap _map;

        public SlideWalker(Tilemap map)
        {
            _map = map;
        }

        public Vector2 Walk(Vector2 start, Vector2 direction)
        {
            var step = _map.layoutGrid.cellSize.x;
            var collider = _map.transform.parent.GetComponentInChildren<Collider2D>();

            var end = start;
            var nextPoint = end + direction * step;
            while (!collider.OverlapPoint(nextPoint))
            {
                end = nextPoint;
                nextPoint += direction * step;
            }

            return end;
        }
    }
}