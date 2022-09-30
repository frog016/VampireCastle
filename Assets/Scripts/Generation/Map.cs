using System.Collections.Generic;
using System.Linq;
using Edgar.Legacy.Utils;
using UnityEngine;

public class Map : MonoBehaviour
{
    private Dictionary<Vector2, bool> _insidePositions;

    private void Awake()
    {
        _insidePositions = new Dictionary<Vector2, bool>();
    }

    public void TakeUpPositions(Vector2[] positions)
    {
        var copy = positions.ToArray();
        copy.Shuffle(new System.Random(0));
        _insidePositions = copy.ToDictionary(key => key, _ => false);
    }

    public bool TryAdd(Vector2 position)
    {
        if (!ContainsPosition(position))
            return false;

        _insidePositions[position] = true;
        return true;
    }

    public void Clear()
    {
        _insidePositions.Clear();
    }

    public Vector2[] GetFreePositions()
    {
        return _insidePositions
            .Where(pair => !pair.Value)
            .Select(pair => pair.Key)
            .ToArray();
    }

    public bool ContainsPosition(Vector2 position) => _insidePositions.ContainsKey(position);

    public bool IsEmpty(Vector2 position) => !_insidePositions[position];
}
