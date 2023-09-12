using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _place;

    private Transform[] _points;
    private int _currentPoint;

    void Start()
    {
        _points = new Transform[_place.childCount];

        for (int i = 0; i < _place.childCount; i++)
            _points[i] = _place.GetChild(i);
    }

    public void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (transform.position == target.position)
            GetNextTargetPoint();
    }
    public Vector3 GetNextTargetPoint()
    {
        _currentPoint++;

        if (_currentPoint >= _points.Length)
            _currentPoint = 0;

        var targetPoint = _points[_currentPoint].transform.position;
        transform.forward = targetPoint - transform.position;

        return targetPoint;
    }
}