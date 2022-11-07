using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderExpand : MonoBehaviour
{
    //[HideInInspector] public Collider expand;
    public BoxCollider expand;
    public BoxCollider parentCol;

    void OnEnable()
    {
        expand = transform.Find("ExpandCollider").GetComponent<BoxCollider>();
        parentCol = this.gameObject.GetComponent<BoxCollider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            expand.enabled = true;
            parentCol.enabled = false;
            //StartCoroutine(CollderDisable());
        }
    }

    IEnumerator CollderDisable()
    {
        yield return new WaitForSeconds(0.02f);
        parentCol.enabled = false;
    }
}