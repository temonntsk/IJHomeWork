using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    private float _maxVolumeIncrease = 2f;
    private float _duration = 2f;
    private float _infiniteRepetition = -1f;

    private void Start()
    {
        transform.DOScale(new Vector3(_maxVolumeIncrease, _maxVolumeIncrease, _maxVolumeIncrease), _duration).SetLoops(_infiniteRepetition, LoopType.Yoyo);
    }
}
