using UnityEngine;

[RequireComponent(typeof(IMovement))]
public class CharacterController : MonoBehaviour
{
    private IInputSystem _inputSystem;
    private IMovement _movement;

    private Vector3 _direction;

    private void Awake()
    {
        _movement = GetComponent<IMovement>();
        _inputSystem = new KeyboardInput(); //GetInputSystem();
    }

    private void Update()
    {
        _direction = _inputSystem.GetMoveDirection().normalized;
    }

    private void FixedUpdate()
    {
        if (_direction.magnitude < 1e-5)
            return;

        _movement.Move(_direction);
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
