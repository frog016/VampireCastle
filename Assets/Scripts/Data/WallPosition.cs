using UnityEngine;

public class WallPosition
{
    public readonly Vector2 WallDirection;
    public readonly Vector2 Position;

    public WallPosition(Vector2 direction, Vector2 position)
    {
        WallDirection = direction;
        Position = position;
    }
}
