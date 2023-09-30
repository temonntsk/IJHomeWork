using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private float _rotationYLength = 360f;
    private float _infiniteRepetition = -1f;
    private float _duration = 3f;

    private void Start()
    {
        transform.DORotate(new Vector3(0, _rotationYLength, 0), _duration, RotateMode.FastBeyond360).SetLoops(_infiniteRepetition, LoopType.Restart).SetEase(Ease.Linear);
    }
}