using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderContract : MonoBehaviour
{
    BoxCollider expandReturn;
    BoxCollider parentReturn;

    void Start()
    {
        expandReturn = this.gameObject.GetComponent<BoxCollider>();
        //parentReturn = gameObject.GetComponentInParent<BoxCollider>();
        parentReturn = transform.parent.GetComponent<BoxCollider>();
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            parentReturn.enabled = true;
            expandReturn.enabled = false;
            //StartCoroutine(ColliderDisable());
        }
    }

    IEnumerator ColliderDisable()
    {
        yield return new WaitForSeconds(0.02f);
        expandReturn.enabled = false;
    }
}