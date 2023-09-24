using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Transform _player;

    private void Start()
    {
        _player = GameObject.FindObjectOfType<Player>().transform;

    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(_player.position.x,_player.position.y,transform.position.z);
    }
}
