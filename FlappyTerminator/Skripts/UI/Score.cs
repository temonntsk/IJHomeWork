using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Duck _duck;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _duck.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _duck.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = score.ToString();
    }
}
