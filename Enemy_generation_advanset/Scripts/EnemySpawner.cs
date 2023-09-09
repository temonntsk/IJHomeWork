using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _spawnTime;
    [SerializeField] private int _countEnemy;

    private void Start()
    {
        StartCoroutine(SpawnEnemys(_spawnTime));
    }


    private IEnumerator SpawnEnemys(float duration)
    {
        for (int i = 0; i < _countEnemy; i++)
        {
            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
        
            _spawnPoints[spawnPointNumber].CreateEnemy();

            yield return new WaitForSeconds(duration);
        }
    }
}
