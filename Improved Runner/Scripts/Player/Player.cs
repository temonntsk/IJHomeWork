using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _maxHealth;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        _maxHealth = _health;
        HealthChanged?.Invoke(_health);
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    public void TakeHealth(int health)
    {
        _health = Mathf.Clamp(_health + health, _health, _maxHealth);
        HealthChanged?.Invoke(_health);
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
