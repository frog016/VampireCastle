using System.Collections.Generic;
using System.Linq;
using Edgar.Legacy.Utils;
using UnityEngine;

public class Map : MonoBehaviour
{
    private Dictionary<Vector2, bool> _mapPositions;

    private void Awake()
    {
        _mapPositions = new Dictionary<Vector2, bool>();
    }

    public void TakeUpPositions(Vector2[] positions)
    {
        var copy = positions.ToArray();
        copy.Shuffle(new System.Random(0));
        _mapPositions = copy.ToDictionary(key => key, _ => false);
    }

    public bool TryAdd(Vector2 position)
    {
        if (!ContainsPosition(position))
            return false;

        _mapPositions[position] = true;
        return true;
    }

    public Vector2[] GetFreePositions()
    {
        return _mapPositions
            .Where(pair => !pair.Value)
            .Select(pair => pair.Key)
            .ToArray();
    }

    public bool ContainsPosition(Vector2 position) => _mapPositions.ContainsKey(position);
}
