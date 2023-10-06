using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HumanHealth
{
    public void TakeHeal(int heal)
    {
        _isThatDamage = false;
        CheckingHealth(heal, _isThatDamage);
    }
}
