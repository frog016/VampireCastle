using System.Collections.Generic;
using UnityEngine;

public class PositionValidator : MonoBehaviour
{
    [SerializeField] private List<Transform> _importantPositions;

    public bool TryGetImportantPosition(out Vector2 position)
    {
        position = default;

        if (_importantPositions.Count == 0)
            return false;

        position = _importantPositions[Random.Range(0, _importantPositions.Count)].position;

        return true;
    }
}

