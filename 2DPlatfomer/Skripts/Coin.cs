using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private CoinSpawner _coinSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerHealth>(out PlayerHealth player))
        {
            _coinSpawner.Spawn();
            Destroy(gameObject);
        }
    }

    public void Init(CoinSpawner coinSpawner)
    {
        _coinSpawner = coinSpawner;
    }
}
