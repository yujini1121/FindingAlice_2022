using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Clock : MonoBehaviour
{
    float collidedTime = 0f;
    float appearTime = 3f;

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {   
            Invoke("respawn", 3f);
            gameObject.SetActive(false);

            if (ClockManager.C.clockCounter < 2)
            {
                collidedTime = Time.time;
                ClockManager.C.clockCooldown = 0;
                ClockManager.C.clockCounter++;
            }
        }
    }

    void respawn()
    {
        gameObject.SetActive(true);
    }
}
