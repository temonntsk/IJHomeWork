using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private float _capacityEnemys;
    [SerializeField] private float _capacityAidKits;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject[] prefabEnemys, GameObject prefabAidKits)
    {
        for (int i = 0; i < _capacityEnemys; i++)
        {
            int randomIndex = Random.Range(0, prefabEnemys.Length);

            GameObject spawned = Instantiate(prefabEnemys[randomIndex], _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }

        for (int i = 0; i < _capacityAidKits; i++)
        {
            GameObject spawned = Instantiate(prefabAidKits, _container.transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p => p.activeSelf == false);

        return result != null;
    }
}
