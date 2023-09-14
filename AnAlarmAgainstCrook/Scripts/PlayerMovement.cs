using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _player;

    private void Awake()
    {
        _player = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        _player.AddForce(new Vector3(horizontalMovement, 1, verticalMovement) * _speed * Time.fixedDeltaTime);
    }
}
