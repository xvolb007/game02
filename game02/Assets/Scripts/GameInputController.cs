using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputController : MonoBehaviour
{
    public static GameInputController Instance { get; private set; }
    private InputActions inputActions;
    public event EventHandler OnPlayerAttack;
    private void Awake()
    {
        Instance = this;
        inputActions = new InputActions();
        inputActions.Combat.Attack.started += PlayerAttack_started;
    }
    private void PlayerAttack_started(InputAction.CallbackContext obj)
    {
        Debug.Log("Pressed");
        OnPlayerAttack.Invoke(this, EventArgs.Empty);
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

