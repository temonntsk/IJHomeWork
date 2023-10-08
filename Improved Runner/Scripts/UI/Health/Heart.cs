using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class Heart : MonoBehaviour
{
    [SerializeField] private float _lerpDuration;

    private Image _image;
    private float _startAmount;
    private float _endAmount;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1f;
        _startAmount = 0;
        _endAmount = 1;
    }

    public void ToFill()
    {
        StartCoroutine(Filling(_startAmount, _endAmount, _lerpDuration,Fill));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(_endAmount, _startAmount, _lerpDuration, Destroy));
    }

    private void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

    private void Fill(float value)
    {
        _image.fillAmount = value;
    }

    private IEnumerator Filling(float startValue, float endValue, float duration, UnityAction<float> lerpigEnd)
    {
        float elapsed = 0;
        float nextValue;

        while (elapsed < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            _image.fillAmount = nextValue;
            elapsed += Time.deltaTime;
            yield return null;
        }

        lerpigEnd?.Invoke(endValue);
    }
}
