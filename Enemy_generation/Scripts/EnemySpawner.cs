using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnsEnemy;
    [SerializeField] private Transform _movePoint;
    [SerializeField] private float _spawnTime;

    private float _delayTime = 0;
    private Transform[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = new Transform[_spawnsEnemy.childCount];

        for (int i = 0; i < _spawnsEnemy.childCount; i++)
        {
            _spawnPoints[i] = _spawnsEnemy.GetChild(i);
        }
    }

    private void Update()
    {
        _delayTime += Time.deltaTime;

        if (_delayTime >= _spawnTime)
        {
            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
            Enemy enemy = Instantiate(_enemyPrefab, _spawnPoints[spawnPointNumber]);
            enemy.SetTarget(_movePoint);
            _delayTime = 0;
        }
    }
}
