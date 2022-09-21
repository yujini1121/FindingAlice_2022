using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Attr
{
    normal = 0,
    sink = 1,
    canUp = 2,
    disappear = 4,
    button = 8,
}
public class PlatformManager : MonoBehaviour
{
    public int attr;


    public virtual void Function(int attr) { }
}

public class SinkTest : PlatformManager
{
    public override void Function(int attr)
    {
        if(attr == 1)
        {
            Debug.Log($"atrribute = {attr}");
        }
    }
}