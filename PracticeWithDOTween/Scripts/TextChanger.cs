using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Text))]

public class TextChanger : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();

        Sequence sequence = DOTween.Sequence();

        sequence.Append(_text.DOText("������ ������", 2));
        sequence.Append(_text.DOText(" ���������� ������", 2).SetRelative());
        sequence.Append(_text.DOText("����� ������", 2, true, ScrambleMode.All));       
    }
}
