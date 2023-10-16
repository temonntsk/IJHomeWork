using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private Camera _camera;
    private List<Enemy> _pool = new List<Enemy>();

    protected void Initialize(Enemy[] prefabs)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            int randomIndex = Random.Range(0, prefabs.Length);

            Enemy spawned = Instantiate(prefabs[randomIndex], _container.transform);
            spawned.gameObject.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out Enemy result)
    {
        result = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return result != null;
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
            item.gameObject.SetActive(false);
    }

    protected void DisableObjectAbroadScree()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0,0.5f));

        foreach (var item in _pool)
        {
            if (item.gameObject.activeSelf == true)
            {
                if (item.transform.position.x < disablePoint.x)
                    item.gameObject.SetActive(false);
            }
        }   
    }
}
