using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Transform))]

public class AidKitSpawner : MonoBehaviour
{
    [SerializeField] private AidKit _aidKit;

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
        AidKit aidKit = Instantiate(_aidKit, _points[GetRandomSpawnPointIndex()].transform.position, Quaternion.identity);
        aidKit.Init(this);
    }

    private int GetRandomSpawnPointIndex()
    {
        int spawnPointIndex = Random.Range(0, _points.Length);

        return spawnPointIndex;
    }
}
