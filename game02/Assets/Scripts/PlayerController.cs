using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float movingSpeed = 5f;
    private InputActions inputActions;
    private Rigidbody2D rigidbody2D;
    private Vector2 inputVector;

    private void Awake()
    {
        inputActions = new InputActions();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        inputVector = inputActions.Player.Move.ReadValue<Vector2>();
    }
    void FixedUpdate()
    {
        Vector2 move = inputVector;

        Debug.Log("Input Vector: " + inputVector);
        Debug.Log($"Normalized Input Vector: " + inputVector.normalized);



        rigidbody2D.MovePosition(rigidbody2D.position + inputVector * movingSpeed * Time.fixedDeltaTime);
    }
}
