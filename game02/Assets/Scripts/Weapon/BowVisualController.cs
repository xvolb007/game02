using UnityEngine;

public class BowVisualController : MonoBehaviour
{
    [SerializeField] private float _orbitRadius = 0.7f;
    [SerializeField] private float _verticalOffset = 0.5f;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        OrbitAroundPlayer();
    }

    private void OrbitAroundPlayer()
    {
        Vector2 mouseScreen = GameInputController.Instance.GetMousePosition();
        Vector2 mouseWorld = _camera.ScreenToWorldPoint(mouseScreen);

        Vector2 playerCenter = (Vector2)PlayerController.Instance.transform.position + Vector2.up * _verticalOffset;

        Vector2 direction = (mouseWorld - playerCenter).normalized;

        transform.position = playerCenter + direction * _orbitRadius;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
