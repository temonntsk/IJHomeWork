using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMovement : MonoBehaviour
{
    private readonly int MoveX = Animator.StringToHash(nameof(MoveX));
    private readonly int Jump = Animator.StringToHash(nameof(Jump));

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private GroundChecker _groundCheck;

    private Animator _animator;
    private Rigidbody2D _player;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _moveVector;
    private bool _isJumping = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ButtonPressReader();
    }

    private void FixedUpdate()
    {
        JumpFromGround();
        Run();
    }

    private void JumpFromGround()
    {
        if (_isJumping && _groundCheck.OnGround)
        {
            _player.velocity = new Vector2(_player.velocity.x, _jumpForce);
            _animator.SetTrigger(Jump);
            _isJumping = false;
        }
    }

    private void Run()
    {
        _animator.SetFloat(MoveX, Mathf.Abs(_moveVector.x));
        _player.velocity = new Vector2(_speed * _moveVector.x, _player.velocity.y);
        Reflect();
    }

    private void ButtonPressReader()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _isJumping = !_isJumping;

        _moveVector.x = Input.GetAxis("Horizontal");
    }

    private void Reflect()
    {
        _spriteRenderer.flipX = _moveVector.x > 0;
    }
}
