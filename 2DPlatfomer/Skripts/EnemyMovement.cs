using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class EnemyMovement : MonoBehaviour
{
    private readonly int MoveX = Animator.StringToHash(nameof(MoveX));

    [SerializeField] private float _speed;

    private PivotPointChecker _pivotPointChecker;
    private Vector2 _moveVector = new Vector2(-1, 1);
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _pivotPointChecker = GetComponentInChildren<PivotPointChecker>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        GetDirections();
        transform.Translate(new Vector3(_moveVector.x, 0, 0) * _speed * Time.deltaTime);
        _animator.SetFloat(MoveX, Mathf.Abs(_moveVector.x));
    }

    private void GetDirections()
    {
        if (_pivotPointChecker.IsReached)
        {
            _moveVector *= new Vector2(-1, 1);
            Reflect();
        }
    }

    private void Reflect()
    {
        _spriteRenderer.flipX = _moveVector.x > 0;
    }
}
