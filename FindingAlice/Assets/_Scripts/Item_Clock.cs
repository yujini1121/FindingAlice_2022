using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Clock : MonoBehaviour
{
    float collidedTime = 0f;
    float appearTime = 3.0f;

    [SerializeField] GameObject childObject;
    Collider collider;

    private void Awake()
    {
        collider = gameObject.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            StartCoroutine(ReSpawn());

            if (ClockManager.C.clockCounter < 2)
            {
                collidedTime = Time.time;
                ClockManager.C.clockCooldown = 0;
                ClockManager.C.clockCounter++;
            }
        }
    }

    IEnumerator ReSpawn()
    {
        childObject.SetActive(false);
        collider.enabled = false;
        yield return new WaitForSeconds(appearTime);

        childObject.SetActive(true);
        collider.enabled = true;
    }
}
