using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] protected Bullet Bullet;

    private bool _isByed = false;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsByed => _isByed;

    public abstract void Shoot(Transform shootPoint);

    public void Buy()
    {
        _isByed = true;
    }
}
