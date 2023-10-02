using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;

    private int _minHealth = 0;
    private bool _isThatDamage;

    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;

    public event Action<int> HealthChanged;

    public void TakeDamage(int damage)
    {
        _isThatDamage = true;
        CheckingHealth(damage, _isThatDamage);
        HealthChanged?.Invoke(_health);
    }

    public void TakeHeal(int heal)
    {
        _isThatDamage = false;
        CheckingHealth(heal, _isThatDamage);
        HealthChanged?.Invoke(_health);
    }

    private void CheckingHealth(int value, bool isThatDamage)
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
    }
}
