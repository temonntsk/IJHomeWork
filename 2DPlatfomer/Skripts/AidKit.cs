using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidKit : MonoBehaviour
{
    private AidKitSpawner _aidKitSpawner;
    private int _numberHealthPoints = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            _aidKitSpawner.Spawn();
            Destroy(gameObject);
            player.TakeHeal(_numberHealthPoints);
        }
    }

    public void Init(AidKitSpawner aidKitSpawner)
    {
        _aidKitSpawner = aidKitSpawner;
    }
}
