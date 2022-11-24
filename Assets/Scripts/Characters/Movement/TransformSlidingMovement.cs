using UnityEngine;

public class TransformSlidingMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float _speed;

    private Vector2 _direction;

    public void Move(Vector2 direction)
    {
        throw new System.NotImplementedException();
    }
}