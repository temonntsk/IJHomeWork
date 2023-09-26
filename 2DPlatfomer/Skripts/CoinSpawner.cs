using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            _points[i] = transform.GetChild(i).transform;

        Spawn();
    }

    public void Spawn()
    {
        Coin coin = Instantiate(_coin, _points[GetRandomSpawnPointIndex()].transform.position, Quaternion.identity);
        coin.Init(this);
    }

    private int GetRandomSpawnPointIndex()
    {
        int spawnPointIndex = Random.Range(0, _points.Length);

        return spawnPointIndex;
    }
}