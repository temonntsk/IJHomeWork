using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shotgun : Weapon
{
    private Transform _currentShootPoint;
    private Vector3[] _shootPoints;

    public override void Shoot(Transform shootPoint)
    {
        if (_currentShootPoint == null)
            SaveShotPositions(shootPoint);

        for (int i = 0; i < _shootPoints.Length; i++)
            Instantiate(Bullet, _shootPoints[i], Quaternion.identity);
    }

    private void SaveShotPositions(Transform shootPoint)
    {
        _currentShootPoint = shootPoint;

        _shootPoints = new Vector3[]
        {
            new Vector3(_currentShootPoint.position.x, _currentShootPoint.position.y+ 0.2f, _currentShootPoint.position.z),
            new Vector3(_currentShootPoint.position.x, _currentShootPoint.position.y, _currentShootPoint.position.z),
            new Vector3(_currentShootPoint.position.x, _currentShootPoint.position.y- 0.2f, _currentShootPoint.position.z)
        };
    }


}
