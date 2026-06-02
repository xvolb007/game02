using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    private float _movingSpeed = 5f;
    private Camera _mainCamera;

    private Rigidbody2D rigidbody2D;
    public Vector2 inputVector;

    private void Awake()
    {
        Instance = this;
        rigidbody2D = GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;
    }
    private void Start()
    {
        GameInputController.Instance.OnPlayerAttack += Player_OnPlayerAttack;
    }

    private void Player_OnPlayerAttack(object sender, EventArgs e)
    {
        Debug.Log("Pressed in Player Controller");
    }

    void Update()
    {
        inputVector = GameInputController.Instance.GetMovementVector();
    }
    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + inputVector * _movingSpeed * Time.fixedDeltaTime);
    }
    public Vector3 GetPlayerScreenPosition()
    {
        Vector3 playerScreenPosition = _mainCamera.WorldToScreenPoint(transform.position);
        return playerScreenPosition;
    }
}
