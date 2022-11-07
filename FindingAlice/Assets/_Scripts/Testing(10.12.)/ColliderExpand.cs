using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderExpand : MonoBehaviour
{
    [HideInInspector] public Collider expand;
    [HideInInspector] public Collider parentCol;

    void Awake()
    {
        expand = GameObject.Find("ExpandCollider").GetComponentInChildren<Collider>();
        parentCol = this.gameObject.GetComponent<Collider>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            expand.enabled = true;
            parentCol.enabled = false;
        }
    }
}