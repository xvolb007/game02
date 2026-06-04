using UnityEngine;

public class ActiveWeaponController : MonoBehaviour
{
    private SwordController _swordController;
    private PlayerController _playerController;
    private void Awake()
    {
        _swordController = GetComponentInChildren<SwordController>();
        _playerController = GetComponentInParent<PlayerController>();
    }
    private void Update()
    {
        HandleRotation();
    }
    public SwordController GetActiveWeapon()
    {
        return _swordController;
    }
    private void HandleRotation()
    {
        Vector3 mousePosition = GameInputController.Instance.GetMousePosition();
        Vector3 playerPosition = _playerController.GetPlayerScreenPosition();
        transform.rotation = Quaternion.Euler(0, mousePosition.x < playerPosition.x ? 180 :0,0);
    }
}
public class Bow : IWeapon
{
    public void Attack()
    {
        Debug.Log("Bow Attack");
    }
}
public class Sword : IWeapon
{
    public void Attack()
    {
        Debug.Log("Sword Attack");
    }
}
public interface IWeapon
{
    void Attack();
}