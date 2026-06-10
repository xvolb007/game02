using UnityEngine;

namespace Assets.Scripts.Weapon
{
    public interface IWeapon
    {
        void Attack();
        GameObject GetGameObject();
    }
}