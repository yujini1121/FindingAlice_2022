using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    public int id;
    public bool checkRead = false;

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.name == "CheckWall" || collision.gameObject.name == "Player")
        //{
        //    gameObject.GetComponent<Collider>().enabled = false;
        //}
        if (collision.gameObject.tag != "Attack" && 
            collision.gameObject.tag != "Platform" && 
            collision.gameObject.tag != "Clock") 
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}