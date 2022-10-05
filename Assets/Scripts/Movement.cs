using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;
    private Tilemap _tilemap;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Tilemap tilemap)
    {
        _tilemap = tilemap;
    }

    public void TryMove(Vector3 direction)
    {
        if (_rigidbody.velocity.magnitude > 1e-3)
            return;

        transform.rotation = Quaternion.Euler(0, Quaternion.FromToRotation(Vector3.right, direction).eulerAngles.y, 0);

        var nextPoint = transform.position + direction / 2;
        if (_tilemap.HasTile(_tilemap.WorldToCell(nextPoint)))
        {
            _rigidbody.velocity = Vector3.zero;
            return;
        }

        _rigidbody.velocity = direction * _speed;
    }
}
