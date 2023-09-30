using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    private float _duration = 30f;
    private float _targetPosition = 30f;

    private void Start()
    {
        transform.DOMoveZ(_targetPosition, _duration);
    }
}