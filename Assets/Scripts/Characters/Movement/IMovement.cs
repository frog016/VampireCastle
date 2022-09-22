using UnityEngine;

public interface IMovement
{
    bool IsMoving { get; }
    void Move(Vector2 direction);
}
