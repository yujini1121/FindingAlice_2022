using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    public int id;
    public bool checkRead = false;

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag != "Attack" &&
    //        other.gameObject.tag != "Platform" &&
    //        other.gameObject.tag != "Clock")
    //    {
    //        gameObject.GetComponent<Collider>().enabled = false;
    //    }
    //}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            gameObject.GetComponent<Collider>().enabled = false;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CheckWall"))
            gameObject.GetComponent<Collider>().enabled = false;
    }
}