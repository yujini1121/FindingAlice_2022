using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderContract : MonoBehaviour
{
    Collider ExpandReturn;
    Collider ParentReturn;

    void Start()
    {
        ExpandReturn = gameObject.GetComponentInParent<ColliderExpand>().expand;
        ParentReturn = gameObject.GetComponentInParent<ColliderExpand>().parentCol;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ExpandReturn.enabled = false;
            ParentReturn.enabled = true;
        }
    }
}