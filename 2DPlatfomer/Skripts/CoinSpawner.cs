using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private Transform _point;
    private Transform[] _points;

    private void Start()
    {
        _point = GetComponent<Transform>();

        _points = new Transform[_point.childCount];

        for (int i = 0; i < _point.childCount; i++)
            _points[i] = _point.GetChild(i).transform;

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