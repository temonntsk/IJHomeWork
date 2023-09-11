using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCubeRotate : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * _rotateSpeed * Time.deltaTime);
    }
}
