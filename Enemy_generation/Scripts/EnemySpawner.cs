using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform _spawnsEnemy;
    [SerializeField] private Transform _movePoint;
    [SerializeField] private float _spawnTime;
    [SerializeField] private int _countEnemy;

    private Transform[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = new Transform[_spawnsEnemy.childCount];

        for (int i = 0; i < _spawnsEnemy.childCount; i++)
        {
            _spawnPoints[i] = _spawnsEnemy.GetChild(i);
        }

        StartCoroutine(SpawnsEnemy(_spawnTime));
    }


    private IEnumerator SpawnsEnemy(float duration)
    {
        for (int i = 0; i < _countEnemy; i++)
        {
            var wait = new WaitForSeconds(duration);

            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

            Enemy enemy = Instantiate(_prefab, _spawnPoints[spawnPointNumber]);
            enemy.SetTarget(_movePoint);

            yield return wait;
        }
    }
}
