using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCombat : HumanCombat
{
    private EnemyDetector _enemyChecker;
    private PlayerHealth _playerHealth;

    protected override void Start()
    {
        base.Start();
        _enemyChecker = GetComponentInChildren<EnemyDetector>();
        _playerHealth = GetComponentInChildren<PlayerHealth>();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && _playerHealth.IsDead==false)
            Attack();
    }

    protected override IEnumerator ImpactPlayback()
    {
        var wait = new WaitForSeconds(_durationAttack);

        _animator.SetTrigger(SwordSwing);

        if (_enemyChecker.Enemy != null)
        {
            EnemyHealth enemy = _enemyChecker.Enemy;
            enemy.TakeDamage(_damage);
        }

        yield return wait;

        _attackSwordSwing = null;
    }
}
