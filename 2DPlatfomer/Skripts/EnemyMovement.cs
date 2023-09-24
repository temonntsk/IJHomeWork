using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private PivotPointChecker _pivotPointChecker;
    private Vector2 _moveVector = new Vector2(-1, 1);
    private bool _isFaceRight = false;
    private Animator _animator;

    private void Awake()
    {
        _pivotPointChecker = GetComponentInChildren<PivotPointChecker>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        GetDirections();
        transform.Translate(new Vector3(_moveVector.x, 0, 0) * _speed * Time.deltaTime);
        _animator.SetFloat("MoveX", Mathf.Abs(_moveVector.x));
    }

    private void GetDirections()
    {
        if (_pivotPointChecker.IsPivotPoint)
        {
            _moveVector *= new Vector2(-1, 1);
            Reflect();
        }
    }

    private void Reflect()
    {
        if ((_moveVector.x > 0 && _isFaceRight == false) || (_moveVector.x < 0 && _isFaceRight == true))
        {
            transform.localScale *= new Vector2(-1, 1);
            _isFaceRight = !_isFaceRight;
        }
    }
}
