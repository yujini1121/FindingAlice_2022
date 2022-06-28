using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Platform")
            ClockManager.C.clockcollided = true;
    }
}
