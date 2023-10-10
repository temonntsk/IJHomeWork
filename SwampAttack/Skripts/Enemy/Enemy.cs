using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;

    [SerializeField] private Player _target;
    private int _maxHealth;
    private int _minHealth = 0;

    public event UnityAction Dying;

    public Player Target => _target;

    private void Awake()
    {
        _maxHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health - damage, _minHealth, _maxHealth);

        if (_health == _minHealth)
            Destroy(gameObject);
    }
}
