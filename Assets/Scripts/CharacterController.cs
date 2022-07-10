using UnityEngine;

[RequireComponent(typeof(Movement))]
public class CharacterController : MonoBehaviour
{
    private Movement _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Update()
    {
        var direction = GetDirection().normalized;
        if (direction.magnitude > 1e-3)
            _movement.TryMove(direction);
    }

    private Vector2 GetDirection()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        return Mathf.Abs(x) > Mathf.Abs(y) ? new Vector2(x, 0) : new Vector2(0, y);
    }
}
