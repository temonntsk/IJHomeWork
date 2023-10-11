using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _enemyPrefabs;
    [SerializeField] private GameObject _aidKitPrefab;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;

    private void Start()
    {
        Initialize(_enemyPrefabs, _aidKitPrefab);
        StartCoroutine(SpawnEnemys());
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPoint;
    }

    private IEnumerator SpawnEnemys()
    {
        var wait = new WaitForSeconds(_secondsBetweenSpawn);

        while (TryGetObject(out GameObject enemy))
        {
            int spawnPointNumber = UnityEngine.Random.Range(0, _spawnPoints.Length);

            SetEnemy(enemy, _spawnPoints[spawnPointNumber].position);

            yield return wait;
        }
    }

}
