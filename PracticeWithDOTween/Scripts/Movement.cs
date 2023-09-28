using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    private void Start()
    {
        transform.DOMoveZ(50, 30);
    }
}
