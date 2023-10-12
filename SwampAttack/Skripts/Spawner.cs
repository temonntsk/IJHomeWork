using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Player _player;

    private Wave _currentWawe;
    private int _currentWaweNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;

    public event UnityAction AllEnemySpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_currentWaweNumber);
    }

    private void Update()
    {
        if (_currentWawe == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWawe.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawned,_currentWawe.Count);
        }

        if (_currentWawe.Count <= _spawned)
        {
            if (_waves.Count > _currentWaweNumber + 1)
            {
                AllEnemySpawned?.Invoke();
            }

            _currentWawe = null;
        }
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWawe.Template, _spawnPoint.position, _spawnPoint.rotation, _spawnPoint);
        enemy.Init(_player);
        enemy.Dying += OnEnemyDying;
    }

    private void SetWave(int index)
    {
        _currentWawe = _waves[index];
        EnemyCountChanged?.Invoke(0, 1);
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;

        _player.AddMoney(enemy.Reward);
    }

    public void NextWave()
    {
        SetWave(++_currentWaweNumber);
        _spawned = 0;
    }
}
