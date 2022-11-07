using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderContract : MonoBehaviour
{
    BoxCollider expandOff;
    BoxCollider parentOn;

    bool col_To_Wall;

    void Start()
    {
        expandOff = this.gameObject.GetComponent<BoxCollider>();
        parentOn = transform.parent.GetComponent<BoxCollider>();
        col_To_Wall = GameObject.Find("Player").GetComponent<PlayerMovement>().collisionToWall;
    }

    void OnCollisionEnter(Collision collision)
    {
        col_To_Wall = false;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            parentOn.enabled = true;
            expandOff.enabled = false;
            col_To_Wall = false;
        }
    }
}