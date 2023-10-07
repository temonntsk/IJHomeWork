using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HumanHealth : MonoBehaviour
{
    [SerializeField] protected float MaxHealth;
    [SerializeField] protected float Health;

    protected float MinHealth = 0;
    private Animator _animator;
    private readonly int Hit = Animator.StringToHash(nameof(Hit));
    private readonly int isDead = Animator.StringToHash(nameof(isDead));

    public bool IsDead => Health==0;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        _animator.SetTrigger(Hit);
        Health = Mathf.Clamp((Health - damage), MinHealth, MaxHealth);
    }
}
