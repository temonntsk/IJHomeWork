using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;

    private int _minHealth = 0;

    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;

    public event Action<int> HealthChanged;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        _health = Mathf.Clamp((_health - damage), _minHealth, _maxHealth);
    }

    public void TakeHeal(int heal)
    {
        _health += heal;
        HealthChanged?.Invoke(_health);

        _health = Mathf.Clamp((_health + heal), _minHealth, _maxHealth);
    }
}
