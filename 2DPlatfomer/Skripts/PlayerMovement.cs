using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundCheck _groundCheck;

    private Animator _animator;
    private Rigidbody2D _player;
    private Vector2 _moveVector;
    private bool _isFaceRight = false;
    private bool _isJumping = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        PressedButton();
    }

    private void FixedUpdate()
    {
        Jump();
        Run();
    }

    private void Jump()
    {
        if (_isJumping && _groundCheck.onGround)
        {
            _player.velocity = new Vector2(_player.velocity.x, _jumpForce);
            _animator.SetTrigger("Jump");
            _isJumping = false;
        }
    }

    private void Run()
    {
        
        _animator.SetFloat("MoveX", Mathf.Abs(_moveVector.x));
        _player.velocity = new Vector2(_speed * _moveVector.x, _player.velocity.y);

        Reflect();
    }

    private void PressedButton()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _isJumping = !_isJumping;

        _moveVector.x = Input.GetAxis("Horizontal");
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
