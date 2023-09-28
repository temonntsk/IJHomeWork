using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]

public class ChangerColor: MonoBehaviour
{
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material.DOColor(Color.red, 2).SetLoops(-1,LoopType.Yoyo);
    }
}
