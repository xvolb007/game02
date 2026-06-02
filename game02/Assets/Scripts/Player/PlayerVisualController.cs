using UnityEngine;

public class PlayerVisualController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer _spriteRenderer;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        HandleAnimation();
        HandleRotation();
    }
    private void HandleAnimation()
    {
        var input = PlayerController.Instance.inputVector;
        animator.SetFloat("Speed", input.magnitude);
    }
    private void HandleRotation()
    {
        Vector3 mouseScreen = GameInputController.Instance.GetMousePosition();
        Vector3 playerPosition = PlayerController.Instance.GetPlayerScreenPosition();
        _spriteRenderer.flipX = mouseScreen.x < playerPosition.x;
    }
}
