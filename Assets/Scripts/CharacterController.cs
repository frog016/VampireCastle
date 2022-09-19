using UnityEngine;

[RequireComponent(typeof(Movement))]
public class CharacterController : MonoBehaviour
{
    private Vector3 _direction;
    private Movement _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        _direction = GetDirection().normalized;
    }

    private void FixedUpdate()
    {
        _movement.TryMove(_direction);
    }

    private static Vector2 GetDirection()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        return Mathf.Abs(x) > Mathf.Abs(y) ? new Vector2(x, 0) : new Vector2(0, y);
    }
}
