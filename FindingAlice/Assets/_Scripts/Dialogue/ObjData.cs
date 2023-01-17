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
        if (collision.gameObject.tag != "Attack" &&
            collision.gameObject.tag != "Platform" &&
            collision.gameObject.tag != "Clock")
        {
            //gameObject.GetComponent<Collider>().enabled = false;
            Destroy(gameObject);
        }
    }

}