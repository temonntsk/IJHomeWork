using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AllAnimationCube : MonoBehaviour
{
    private float _scaleSpeed = 0.1f;
    private float _moveSpeed = 2f;
    private float _rotateSpeed = 40f;

    private void Update()
    {
        transform.localScale += new Vector3(GetSizeValueInTime(1f), GetSizeValueInTime(1f), GetSizeValueInTime(1f));
        transform.Translate(new Vector3(0, 0, 1) * _moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 1, 0) * _rotateSpeed * Time.deltaTime);
    }

    private float GetSizeValueInTime(float value)
    {
        return value * _scaleSpeed * Time.deltaTime;
    }
}
