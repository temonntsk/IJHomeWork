using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
        BarSlider.value = 1;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }
}
