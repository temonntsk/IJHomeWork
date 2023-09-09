using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private Transform _target;

    public Enemy CreateEnemy()
    {
        Enemy enemy = Instantiate(_prefab, transform);
        enemy.SetTarget(_target);

        return enemy;
    }
}
