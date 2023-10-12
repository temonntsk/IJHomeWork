using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _reward;
    [SerializeField] private Player _target;

    private int _maxHealth;
    private int _minHealth = 0;

    public int Money { get; private set; }

    public int Reward => _reward;

    public Player Target => _target;

    public event UnityAction<Enemy> Dying;

    public void Init(Player target)
    {
        _target = target;
    }

    private void Awake()
    {
        _maxHealth = _health;
    }

    public void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health - damage, _minHealth, _maxHealth);

        if (_health == _minHealth)
        {
            Dying?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
