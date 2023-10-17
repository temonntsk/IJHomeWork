using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckBullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Duck _duck;

    private void Update()
    {
        transform.Translate(transform.right * _speed * Time.deltaTime, Space.Self);
    }

    public void Init(Duck duck)
    {
        _duck = duck;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            enemy.Die();
            _duck.IncreaseScore();
            Destroy(gameObject);
        }
    }
}