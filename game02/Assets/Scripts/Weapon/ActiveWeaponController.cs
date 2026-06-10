using Assets.Scripts.Enums;
using Assets.Scripts.Weapon;
using System;
using UnityEngine;

public class ActiveWeaponController : MonoBehaviour
{
    private SwordController _swordController;
    private BowController _bowController;
    private PlayerController _playerController;

    private IWeapon _activeWeapon;
    private IWeapon[] _weapons;
    
    private void Awake()
    {
        _swordController = GetComponentInChildren<SwordController>();
        _bowController = GetComponentInChildren<BowController>();
        _playerController = GetComponentInParent<PlayerController>();
        _weapons = new IWeapon[] { _swordController, _bowController };
    }
    public void Start()
    {
        GameInputController.Instance.OnWeaponSwitch += Input_OnWeaponSwitch;
        //OnPlayerAttack
        SetWeapon(WeaponType.Sword);
    }

    private void Update()
    {
        HandleRotation();
    }
    private void Input_OnWeaponSwitch(object sender, GameInputController.OnWeaponSwitchArgs e)
    {
        throw new NotImplementedException();
    }
    private void SetWeapon(WeaponType weaponType)
    {
        int index = (int)weaponType;
        if (index < 0 || index >= _weapons.Length)
        {
            Debug.LogError($"Invalid weapon type: {weaponType}");
            return;
        }
        foreach (var w in _weapons)
        {
            w.GetGameObject().SetActive(false);
        }
        _activeWeapon = _weapons[index];
        _activeWeapon.GetGameObject().SetActive(true);

        Debug.Log($"Switched to weapon: {weaponType}");
    }
    public IWeapon GetActiveWeapon()
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