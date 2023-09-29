using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class Bar : MonoBehaviour
{
    [SerializeField] private float _step;
    [SerializeField] private Player _player;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _player.MaxHealth;
        _slider.minValue = _player.MinHealth;
    }

    private void OnEnable()
    {
        _player.HealthChanged += ChangeValue;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= ChangeValue;
    }

    public void ChangeValue(int health)
    {
        if (health > _player.MaxHealth)
            health = _player.MaxHealth;
        else if (health < _player.MinHealth)
            health = _player.MinHealth;

        StartCoroutine(MoveSlider(_step, health));
    }

    private IEnumerator MoveSlider(float stepValue, int health)
    {
        while (_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, stepValue);

            yield return null;
        }
    }
}
