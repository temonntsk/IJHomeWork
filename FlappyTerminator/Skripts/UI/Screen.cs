using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Screen : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected Button Button;

    private void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClick);
    }

    public void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
    }

    public void Open()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    protected abstract void OnButtonClick();
}
