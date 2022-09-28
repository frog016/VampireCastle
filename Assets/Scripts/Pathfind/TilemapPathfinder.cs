using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Pathfind.Walker;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Pathfind
{
    public class TilemapPathfinder : IPathfinder<Vector2>
    {
        private readonly Tilemap _map;
        private readonly IWalker _walker;

        public TilemapPathfinder(Tilemap map, IWalker walker)
        {
            _map = map;
            _map.CompressBounds();

            _walker = walker;
        }

        public List<Vector2> FindPath()
        {
            var start = FindFreePosition();
            var stack = new Queue<Vector2>(new Vector2[] { start });
            var visited = new HashSet<Vector2>(new Vector2[] { start });

            while (stack.Count != 0)
            {
                var current = stack.Dequeue();
                
                foreach (var direction in GetDirections())
                {
                    var neighbor = _walker.Walk(current, direction);
                    if (visited.Contains(neighbor))
                        continue;

                    stack.Enqueue(neighbor);
                    visited.Add(neighbor);
                }
            }

            return visited.ToList();
        }

        private Vector2 FindFreePosition()
        {
            var collider = _map.transform.parent.GetComponentInChildren<Collider2D>();
            var offset = (Vector2)(_map.layoutGrid.cellSize) / 2;

            var position = GetRandomPosition() + offset;
            while (collider.OverlapPoint(position))
                position = GetRandomPosition() + offset;

            return position;
        }

        private Vector2 GetRandomPosition()
        {
            var tileWorldLocations = _map.GetPositionsWorld().ToList();
            return tileWorldLocations[Random.Range(0, tileWorldLocations.Count)];
        }

        private static Vector2[] GetDirections()
        {
            return new Vector2[]
            {
                Vector2.left,
                Vector2.up,
                Vector2.right,
                Vector2.down,
            };
        }
    }
}