using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckShooter : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private DuckBullet _bullet;
    [SerializeField] private Duck _duck;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot(_shootPoint);
        }
    }

    public void Shoot(Transform shootPoint)
    {
        DuckBullet bullet = Instantiate(_bullet, shootPoint.position, Quaternion.identity);
        bullet.Init(_duck);
        bullet.transform.rotation = _shootPoint.rotation;
    }
}