using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class ChangerColor: MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private float _duration = 2f;
    private float _infiniteRepetition = -1f;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material.DOColor(Color.red, _duration).SetLoops(_infiniteRepetition, LoopType.Yoyo);
    }
}
