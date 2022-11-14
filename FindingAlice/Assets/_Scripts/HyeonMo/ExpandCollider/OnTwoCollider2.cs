using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTwoCollider2 : MonoBehaviour
{
    BoxCollider expandOff1;
    BoxCollider expandOff2;
    BoxCollider parentOn;

    bool col_To_Wall;

    void OnEnable()
    {
        if (this.name == "ExpandCollider1")
        {
            expandOff1 = this.gameObject.GetComponent<BoxCollider>();
            expandOff2 = transform.Find("ExpandCollider2").GetComponent<BoxCollider>();
        }
        else
        {
            expandOff1 = transform.Find("ExpandCollider1").GetComponent<BoxCollider>();
            expandOff2 = this.gameObject.GetComponent<BoxCollider>();
        }
        
        parentOn = transform.parent.GetComponent<BoxCollider>();
        col_To_Wall = GameObject.Find("Player").GetComponent<PlayerMovement>().collisionToWall;
    }

    //void FixedUpdate(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        expandOff1.enabled = false;
    //        expandOff2.enabled = false;
    //        parentOn.enabled = true;
    //        col_To_Wall = false;
    //    }
    //}

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            expandOff1.enabled = false;
            expandOff2.enabled = false;
            parentOn.enabled = true;
            col_To_Wall = false;
        }
    }

}
