using UnityEngine;

public class AndroidInput : IInputSystem
{
    private Vector2 _direction;
    private SwipeDetector _detector;

    public AndroidInput(GameObject owner)
    {
        _detector = owner.AddComponent<SwipeDetector>();
        _detector.OnSwipe += data => _direction = data.Direction;
    }

    public Vector3 GetMoveDirection()
    {
        return _direction;
    }
}
