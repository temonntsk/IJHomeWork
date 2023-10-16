using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckTracker : MonoBehaviour
{
    [SerializeField] private Duck _duck;
    [SerializeField] private float _xOffSet;

    private void Update()
    {
        transform.position = new Vector3(_duck.transform.position.x + _xOffSet, transform.position.y, transform.position.z);
    }
}