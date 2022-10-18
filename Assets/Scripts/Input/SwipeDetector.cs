using System;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    [SerializeField] private bool _detectSwipeOnlyAfterRelease = false;
    [SerializeField] private float _minDistanceForSwipe = 100f;

    private Vector2 _fingerDownPosition;
    private Vector2 _fingerUpPosition;
    public event Action<SwipeData> OnSwipe;

    private void Update()
    {
        TryDetectSwipe();
    }

    private void TryDetectSwipe()
    {
        foreach (var touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                _fingerUpPosition = touch.position;
                _fingerDownPosition = touch.position;
            }

            if ((_detectSwipeOnlyAfterRelease || 
                 touch.phase != TouchPhase.Moved) &&
                touch.phase != TouchPhase.Ended) 
                continue;

            _fingerDownPosition = touch.position;
            DetectSwipe();
        }
    }

    private void DetectSwipe()
    {
        if (!IsSwipeDistanceEnough())
            return;

        var distance = _fingerDownPosition - _fingerUpPosition;
        var direction = IsVerticalSwipe() ? new Vector2(0, distance.y) : new Vector2(distance.x, 0);

        SendSwipe(direction);
        _fingerUpPosition = _fingerDownPosition;
    }

    private bool IsVerticalSwipe()
    {
        var distance = GetMovementDistance();
        return distance.y > distance.x;
    }

    private bool IsSwipeDistanceEnough()
    {
        var distance = GetMovementDistance();
        return distance.y > _minDistanceForSwipe || distance.x > _minDistanceForSwipe;
    }

    private Vector2 GetMovementDistance()
    {
        var distance = _fingerDownPosition - _fingerUpPosition;
        return new Vector2(Mathf.Abs(distance.x), Mathf.Abs(distance.y));
    }

    private void SendSwipe(Vector2 direction)
    {
        var swipeData = new SwipeData(_fingerDownPosition, _fingerUpPosition, direction);
        OnSwipe?.Invoke(swipeData);
    }
}

public struct SwipeData
{
    public Vector2 StartPosition;
    public Vector2 EndPosition;
    public Vector2 Direction;

    public SwipeData(Vector2 start, Vector2 end, Vector2 direction)
    {
        StartPosition = start;
        EndPosition = end;
        Direction = direction;
    }
}

public enum SwipeDirection
{
    Up,
    Down,
    Left,
    Right
}