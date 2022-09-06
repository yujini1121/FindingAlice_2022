using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager
{
    static public void SetActive(GameObject platform)
    {
        if (platform.GetComponent<Sink>() != null)
        {
            platform.GetComponent<Sink>().active = true;
        }
        platform.SetActive(false);
            
    }
}
