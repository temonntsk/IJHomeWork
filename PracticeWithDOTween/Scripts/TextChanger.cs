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

        sequence.Append(_text.DOText("������ ������", _duration));
        sequence.Append(_text.DOText(" ���������� ������", _duration).SetRelative());
        sequence.Append(_text.DOText("����� ������", _duration, true, ScrambleMode.All));       
    }
}
