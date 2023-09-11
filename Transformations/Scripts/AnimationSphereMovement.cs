using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSphereMovement : MonoBehaviour
{
    private Transform _transform;
    private float _speed = 1f;

    private void Start()
    {
        _transform = GetComponent<Transform>();
    }

    private void Update()
    {
        _transform.Translate(new Vector3(0, 0, 1) * _speed * Time.deltaTime);
        
    }
}
