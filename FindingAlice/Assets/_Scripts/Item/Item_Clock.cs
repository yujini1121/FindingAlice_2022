using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Clock : Item
{
    public override void ItemEffectSet()
    {
        if (ClockManager.C.clockCounter < 2)
        {
            collidedTime = Time.time;
            ClockManager.C.clockCooldown = 0;
            ClockManager.C.clockCounter++;
        }
    }
}
