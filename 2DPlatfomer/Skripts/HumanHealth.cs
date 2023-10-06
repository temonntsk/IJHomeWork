using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HumanHealth : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _health;

    protected bool _isThatDamage;
    private float _minHealth = 0;
    private Animator _animator;
    private readonly int Hit = Animator.StringToHash(nameof(Hit));
    private readonly int isDead = Animator.StringToHash(nameof(isDead));

    public bool IsDead => _health==0;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    protected void CheckingHealth(int value, bool isThatDamage)
    {
        _health = Mathf.Clamp(_health, _minHealth, _maxHealth);

        if (_isThatDamage)
        {
            _health -= value;
            _health = Mathf.Clamp((_health - value), _minHealth, _maxHealth);
        }
        else
        {
            _health += value;
            _health = Mathf.Clamp((_health + value), _minHealth, _maxHealth);
        }

        if (IsDead)
        {
            _animator.SetBool(isDead, true);
        }
    }

    public void TakeDamage(int damage)
    {
        _isThatDamage = true;
        _animator.SetTrigger(Hit);
        CheckingHealth(damage, _isThatDamage);
    }
}
