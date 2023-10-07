using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HumanHealth
{
    public void TakeHeal(int heal)
    {
        Health = Mathf.Clamp((Health + heal), MinHealth, MaxHealth);
    }
}
