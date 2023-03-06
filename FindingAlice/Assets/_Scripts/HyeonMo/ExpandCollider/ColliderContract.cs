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
        if (collision.gameObject.tag == "Player")
        {
            col_To_Wall = false;
            StartCoroutine(OneMore());
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            parentOn.enabled = true;
            expandOff.enabled = false;
            col_To_Wall = false;
            StartCoroutine(OneMore());
        }
    }

    //void OnDisable()
    //{
    //    parentOn.enabled = true;
    //    expandOff.enabled = false;
    //    col_To_Wall = false;
    //}

    IEnumerator OneMore()
    {
        yield return new WaitForSeconds(0.2f);
        col_To_Wall = false;
    }
}