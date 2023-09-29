using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _minHealth;
    [SerializeField] private int _health;

    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;


    public Action<int> HealthChanged;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health - damage < _minHealth)
            _health = _minHealth;
    }

    public void TakeHeal(int heal)
    {
        _health += heal;
        HealthChanged?.Invoke(_health);

        if (_health + heal > _maxHealth)
            _health = _maxHealth;
    }
}
