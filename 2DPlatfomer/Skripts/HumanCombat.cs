using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public abstract class HumanCombat : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _durationAttack;

    protected Animator _animator;
    protected readonly int SwordSwing = Animator.StringToHash(nameof(SwordSwing));
    protected Coroutine _attackSwordSwing;

    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
    }

    protected void Attack()
    {
        if (_attackSwordSwing == null)
            _attackSwordSwing = StartCoroutine(ImpactPlayback());
    }

    protected abstract IEnumerator ImpactPlayback();
}
