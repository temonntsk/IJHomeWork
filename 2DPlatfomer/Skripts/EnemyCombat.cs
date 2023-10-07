using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : HumanCombat
{
    private PlayerDetector _playerChecker;
    private EnemyHealth _enemyHealth;

    protected override void Start()
    {
        base.Start();
        _playerChecker = GetComponentInChildren<PlayerDetector>();
        _enemyHealth = GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        if (_playerChecker.Player != null && _enemyHealth.IsDead == false)
            Attack();
    }

    protected override IEnumerator ImpactPlayback()
    {
        var wait = new WaitForSeconds(_durationAttack);

        _animator.SetTrigger(SwordSwing);

        PlayerHealth player = _playerChecker.Player;
        player.TakeDamage(_damage);

        yield return wait;

        _attackSwordSwing = null;
    }
}
