using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class EnemyMovement : MonoBehaviour
{
    private readonly int MoveX = Animator.StringToHash(nameof(MoveX));

    [SerializeField] private float _speed;
    [SerializeField] private float _reactionDistance;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform[] _points;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private EnemyHealth _enemyHealth;
    private float _distanceToPlayer;
    private int _currentPoint;
    private Transform _target;
    private float _currentPosition;

    private void Awake()
    {
        _target = _points[_currentPoint];
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _enemyHealth = GetComponentInChildren<EnemyHealth>();
        _currentPosition = transform.position.x;
    }

    private void Update()
    {
        Move();
        _distanceToPlayer = Vector2.Distance(transform.position, _player.position);
    }
    private void Move()
    {
        transform.position = GetDirections();
        _animator.SetFloat(MoveX, Mathf.Abs(_currentPosition));
        ChangePoint();
        Reflect();
        _currentPosition = transform.position.x;
    }

    private Vector2 GetDirections()
    {

        if (_enemyHealth.IsDead)
            return Vector2.zero;


        if (_distanceToPlayer < _reactionDistance)
        {
            return Vector2.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
        }
        else
        {
            return Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        }
    }

    private void ChangePoint()
    {
        if (transform.position == _target.position)
        {
            _currentPoint++;

            if (_currentPoint == _points.Length)
                _currentPoint = 0;

            _target = _points[_currentPoint];
        }
    }

    private void Reflect()
    {
        if (_currentPosition > transform.position.x)
            _spriteRenderer.flipX = false;
        else
            _spriteRenderer.flipX = true;
    }
}
