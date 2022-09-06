using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ClockManager.C.clockReset();
#if true
        other.gameObject.GetComponent<PlayerMovement>().playerAnim.SetTrigger("isRolling");
#endif
        }
    }
}
