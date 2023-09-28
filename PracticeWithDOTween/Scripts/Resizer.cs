using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour
{
    private void Start()
    {
        transform.DOScale(new Vector3(2, 2, 2), 2).SetLoops(-1, LoopType.Yoyo);
    }
}
