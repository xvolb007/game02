using UnityEngine;

public class ActiveWeaponController : MonoBehaviour
{
    [SerializeField] private SwordController _swordController;
    public static ActiveWeaponController Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
        _swordController = GetComponentInChildren<SwordController>();
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
        Vector3 playerPosition = PlayerController.Instance.GetPlayerScreenPosition();
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