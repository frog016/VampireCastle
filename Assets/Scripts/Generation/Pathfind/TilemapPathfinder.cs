using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Pathfind.Walker;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Pathfind
{
    public class TilemapPathfinder : IPathfinder<Vector2, Tilemap[]>
    {
        private readonly IWalker<Vector2, Tilemap> _walker;

        public TilemapPathfinder(IWalker<Vector2, Tilemap> walker)
        {
            _walker = walker;
        }

        public Vector2[] FindPath(Tilemap[] maps)
        {
            var (floor, wall) = (maps.First(), maps.Last());

            var start = FindFreePosition(floor, wall);
            var stack = new Queue<Vector2>(new Vector2[] { start });
            var visited = new HashSet<Vector2>(new Vector2[] { start });

            while (stack.Count != 0)
            {
                var current = stack.Dequeue();
                
                foreach (var direction in GetDirections())
                {
                    foreach (var neighbor in _walker.Walk(current, direction, wall))
                    {
                        if (visited.Contains(neighbor))
                            continue;

                        stack.Enqueue(neighbor);
                        visited.Add(neighbor);
                    }
                }
            }

            return visited.ToArray();
        }

        private Vector2 FindFreePosition(Tilemap floor, Tilemap wall)
        {
            var offset = (Vector2)(floor.layoutGrid.cellSize) / 2;

            var position = GetRandomPosition(floor) + offset;
            while (wall.HasTile(wall.WorldToCell(position)))
                position = GetRandomPosition(floor) + offset;

            return position;
        }

        private static Vector2 GetRandomPosition(Tilemap map)
        {
            var tileWorldLocations = map.GetPositionsWorld().ToList();
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