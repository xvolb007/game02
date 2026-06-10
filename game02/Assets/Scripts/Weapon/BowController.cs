using Assets.Scripts.Weapon;
using System;
using UnityEngine;

public class BowController : MonoBehaviour, IWeapon
{
    public event EventHandler OnBowShoot;
    public void Attack()
    {
        Debug.Log("Bow Attack");
        OnBowShoot?.Invoke(this, EventArgs.Empty);
    }

    public GameObject GetGameObject()
    {
        return gameObject;
    }
}
