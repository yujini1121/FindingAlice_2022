using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected float collidedTime = 0f;
    protected float appearTime = 3.0f;

    [SerializeField] GameObject childObject;
    Collider collider;

    protected void Awake()
    {
        collider = gameObject.GetComponent<Collider>();
    }

    protected void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            StartCoroutine(ReSpawn());

            ItemEffectSet();
        }
    }
    public IEnumerator ReSpawn()
    {
        childObject.SetActive(false);
        collider.enabled = false;
        yield return new WaitForSeconds(appearTime);

        childObject.SetActive(true);
        collider.enabled = true;
    }
     public abstract void ItemEffectSet();
}
