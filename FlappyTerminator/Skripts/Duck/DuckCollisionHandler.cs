using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Duck))]

public class DuckCollisionHandler : MonoBehaviour
{
    private Duck _duck;

    private void Start()
    {
        _duck = GetComponent<Duck>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy enemy))
            _duck.Die();

    }
}