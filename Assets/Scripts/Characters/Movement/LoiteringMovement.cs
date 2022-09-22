using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LoiteringMovement : MonoBehaviour, IMovement
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _oneDirectionTimeInterval;

    public bool IsMoving { get; private set; }

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public async void Move(Vector2 direction)
    {
        if (IsMoving)
            return;

        _rigidbody.velocity = direction * _speed;
        transform.rotation = Quaternion.Euler(0, Quaternion.FromToRotation(Vector3.right, direction).eulerAngles.y, 0);

        IsMoving = true;
        await Task.Delay((int)(Random.Range(_oneDirectionTimeInterval.x, _oneDirectionTimeInterval.y) * 1000));
        IsMoving = false;
    }
}
