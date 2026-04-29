using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    private float movingSpeed = 5f;
    
    private Rigidbody2D rigidbody2D;
    public Vector2 inputVector;

    private void Awake()
    {
        Instance = this;
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputVector = GameInputController.Instance.GetMovementVector();
    }
    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + inputVector * movingSpeed * Time.fixedDeltaTime);
    }
}
