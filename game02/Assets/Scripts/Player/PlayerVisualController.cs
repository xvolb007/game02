using UnityEngine;

public class PlayerVisualController : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer _spriteRenderer;
    private PlayerController _playerController;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _playerController = GetComponentInParent<PlayerController>();
    }
    private void Update()
    {
        HandleAnimation();
        HandleRotation();
    }
    private void HandleAnimation()
    {
        var input = _playerController.inputVector;
        animator.SetFloat("Speed", input.magnitude);
    }
    private void HandleRotation()
    {
        Vector3 mouseScreen = GameInputController.Instance.GetMousePosition();
        Vector3 playerPosition = _playerController.GetPlayerScreenPosition();
        _spriteRenderer.flipX = mouseScreen.x < playerPosition.x;
    }
}
