using UnityEngine;

[RequireComponent(typeof(SlidingMovement))]
public class CharacterController : MonoBehaviour
{
    private IInputSystem _inputSystem;
    private Movement _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _inputSystem = GetInputSystem();
    }

    private void FixedUpdate()
    {
        var direction = _inputSystem.GetMoveDirection().normalized;
        if (direction.magnitude > 1e-3)
            _movement.TryMove(direction);
    }

    private IInputSystem GetInputSystem()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                return new AndroidInput(gameObject);
            case RuntimePlatform.WindowsPlayer:
                return new KeyboardInput();
            case RuntimePlatform.WindowsEditor:
                return new KeyboardInput();
        }

        return null;
    }
}
