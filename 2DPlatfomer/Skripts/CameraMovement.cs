using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _cameraHeight;


    private void FixedUpdate()
    {
        transform.position = new Vector3(_player.position.x, _player.position.y + _cameraHeight, transform.position.z);
    }
}
