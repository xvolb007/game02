using Assets.Scripts.Weapon;
using System;
using UnityEngine;

public class SwordController : MonoBehaviour, IWeapon
{
    public event EventHandler OnSwordSwing;
    public void Attack()
    {
        Debug.Log("Sword Attack");
        OnSwordSwing?.Invoke(this, EventArgs.Empty);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
