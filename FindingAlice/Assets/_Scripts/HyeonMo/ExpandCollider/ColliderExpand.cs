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
            StartCoroutine(OneMore());
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            col_To_Wall = false;
            StartCoroutine(OneMore());
        }

    }

    //void FixedUpdate(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        expand.enabled = true;
    //        parentCol.enabled = false;
    //        col_To_Wall = false;
    //        //StartCoroutine(OneMore());
    //    }
    //}

    IEnumerator OneMore()
    {
        yield return new WaitForSeconds(0.2f);
        col_To_Wall = false;
    }

}