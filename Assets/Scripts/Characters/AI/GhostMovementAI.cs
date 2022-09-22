using UnityEngine;

[RequireComponent(typeof(IMovement))]
public class GhostMovementAI : MonoBehaviour, IMovementAI
{
    private IMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<IMovement>();
    }

    private void Update()
    {
        TryMove();
    }

    public void TryMove()
    {
        _movement.Move(GetRandomDirection());
    }

    private static Vector3 GetRandomDirection()
    {
        var directions = new Vector2[]
        {
            new Vector2(-1, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(0, -1)
        };

        return directions[Random.Range(0, directions.Length)];
    }
}
