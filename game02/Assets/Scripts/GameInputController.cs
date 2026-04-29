using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputController : MonoBehaviour
{
    public static GameInputController Instance { get; private set; }
    private InputActions inputActions;
    private void Awake()
    {
        Instance = this;
        inputActions = new InputActions();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    public Vector2 GetMovementVector()
    {
        return inputActions.Player.Move.ReadValue<Vector2>();
    }
    public Vector3 GetMousePosition()
    {
        return Mouse.current.position.ReadValue();
    }
}

