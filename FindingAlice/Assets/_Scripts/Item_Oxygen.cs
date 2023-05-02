using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Oxygen : Item
{
    public override void ItemEffectSet()
    {
        
        WaterManager.Instance.GetOxygenItem();
    }
}
