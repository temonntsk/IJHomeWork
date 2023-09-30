using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Text))]

public class TextChanger : MonoBehaviour
{
    private Text _text;
    private float _duration = 2f;

    private void Start()
    {
        _text = GetComponent<Text>();

        Sequence sequence = DOTween.Sequence();

        sequence.Append(_text.DOText("Замена текста", _duration));
        sequence.Append(_text.DOText(" Дополнение текста", _duration).SetRelative());
        sequence.Append(_text.DOText("Смена текста", _duration, true, ScrambleMode.All));       
    }
}
