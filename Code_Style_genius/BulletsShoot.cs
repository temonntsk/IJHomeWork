using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BulletsShooting : MonoBehaviour
{
    [SerializeField] private float _number;
    [SerializeField] private float _shootingTime;
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private Transform _target;

    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        bool isWork = true;
        var wait = new WaitForSeconds(_shootingTime);

        while (isWork)
        {
            var direction = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            newBullet.transform.up = direction;
            newBullet.velocity = direction * _number;

            yield return wait;
        }
    }
}