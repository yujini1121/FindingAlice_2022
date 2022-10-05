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
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            player.DecreaseSpeed();
#if true
            other.gameObject.GetComponent<PlayerMovement>().AnimControl("isRolling");
#endif
        }
    }
}
