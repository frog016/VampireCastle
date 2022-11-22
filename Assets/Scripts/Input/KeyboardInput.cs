using UnityEngine;

public class KeyboardInput : IInputSystem
{
    public Vector3 GetMoveDirection()
    {
        var x = Input.GetAxis("Horizontal");
        var y = Input.GetAxis("Vertical");

        return Mathf.Abs(x) > Mathf.Abs(y) ? new Vector3(x, 0) : new Vector3(0, y);
    }
}
