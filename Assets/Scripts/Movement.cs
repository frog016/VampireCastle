using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void TryMove(Vector2 direction)
    {
        if (_rigidbody.velocity.magnitude > 1e-3)
            return;

        _rigidbody.velocity = direction * _speed;
    }
}
