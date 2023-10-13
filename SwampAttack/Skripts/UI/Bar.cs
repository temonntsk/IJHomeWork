using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] protected Slider BarSlider;

    public void OnValueChanged(int value, int maxValue)
    {
        BarSlider.value = (float)value / maxValue;
    }
}
