using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(DuckMover))]

public class Duck : MonoBehaviour
{
    private DuckMover _mover;
    private int _score;

    public event UnityAction GameOver;
    public event UnityAction<int> ScoreChanged;

    private void Start()
    {
        _mover = GetComponent<DuckMover>();
    }

    public void ReserPlayer()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
        _mover.ResetDuck();
    }

    public void IncreaseScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        GameOver?.Invoke();
    }
}
