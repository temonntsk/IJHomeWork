using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCapsuleIncrease : MonoBehaviour
{
    [SerializeField] private float _scaleSpeed;

    private void Update()
    {
        transform.localScale += new Vector3(GetSizeValueInTime(1f), GetSizeValueInTime(1f), GetSizeValueInTime(1f)) ;
    }

    private float GetSizeValueInTime(float value )
    {
        return value * _scaleSpeed * Time.deltaTime;
    }
}
