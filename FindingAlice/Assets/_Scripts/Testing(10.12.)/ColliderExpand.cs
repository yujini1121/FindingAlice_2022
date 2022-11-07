using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderExpand : MonoBehaviour
{
    BoxCollider expand;
    BoxCollider parentCol;

    bool col_To_Wall;

    void OnEnable()
    {
        expand = transform.Find("ExpandCollider").GetComponent<BoxCollider>();
        parentCol = this.gameObject.GetComponent<BoxCollider>();
        col_To_Wall = GameObject.Find("Player").GetComponent<PlayerMovement>().collisionToWall;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            expand.enabled = true;
            parentCol.enabled = false;
            col_To_Wall = false;
        }
    }
}