using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SlidingMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 direction)
    {
        if (_rigidbody.velocity.magnitude > 1e-3)
            return;

        _rigidbody.velocity = direction * _speed;
        transform.rotation = Quaternion.Euler(0, Quaternion.FromToRotation(Vector3.right, direction).eulerAngles.y, 0);
    }
}
