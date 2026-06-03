using System;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public event EventHandler OnSwordSwing;
    public void Attack()
    {
        Debug.Log("Sword Attack");
        OnSwordSwing?.Invoke(this, EventArgs.Empty);
    }
}
