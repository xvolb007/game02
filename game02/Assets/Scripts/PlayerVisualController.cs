using UnityEngine;

public class PlayerVisualController : MonoBehaviour
{
    private Animator animator;
    private Camera mainCamera;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        mainCamera = Camera.main;
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
        Vector3 mouseWorld = mainCamera.ScreenToWorldPoint(mouseScreen);
        mouseWorld.z = 0;
        Vector3 direction = mouseWorld - transform.position;
        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
