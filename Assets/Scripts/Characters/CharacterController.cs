using UnityEngine;

[RequireComponent(typeof(IMovement))]
public class CharacterController : MonoBehaviour
{
    private IInputSystem _inputSystem;
    private IMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<IMovement>();
        _inputSystem = new KeyboardInput(); //GetInputSystem();
    }

    private void Update()
    {
        _movement.Move(_inputSystem.GetMoveDirection().normalized);
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
