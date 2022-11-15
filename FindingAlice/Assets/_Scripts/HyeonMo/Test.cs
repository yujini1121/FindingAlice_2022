using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
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

    void OnCollisionEnter(Collision collision)
    {
        expand.enabled = true;
        parentCol.enabled = false;
        col_To_Wall = false;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            parentCol.enabled = true;
            expand.enabled = false;
            col_To_Wall = false;
        }

    }

    IEnumerator OneMore()
    {
        yield return new WaitForSeconds(0.1f);
        col_To_Wall = false;
    }
}
