using System;
using UnityEngine;

public class SwordVisualController : MonoBehaviour
{
    private Animator _animator;
    private SwordController _swordController;
    private const string Attack = "Attack";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _swordController = GetComponentInParent<SwordController>();
    }
    private void Start()
    {
        _swordController.OnSwordSwing += Sword_OnSwordSwing;
    }

    private void Sword_OnSwordSwing(object sender, EventArgs e)
    {
        _animator.SetTrigger(Attack);
    }
}
