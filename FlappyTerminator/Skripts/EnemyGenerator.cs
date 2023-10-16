using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : ObjectPool
{
    [SerializeField] private Enemy[] _templates;
    [SerializeField] private float _secondsBetweenSpawn;

    private void Start()
    {
        Initialize(_templates);
        StartCoroutine(SpawnEnemys());
    }

    private IEnumerator SpawnEnemys()
    {
        var wait = new WaitForSeconds(_secondsBetweenSpawn);

        while (TryGetObject(out Enemy enemy))
        {
            enemy.transform.position = transform.position;
            enemy.gameObject.SetActive(true);

            DisableObjectAbroadScree();

            yield return wait;
        }
    }
}
