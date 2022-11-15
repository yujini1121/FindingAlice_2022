using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    public int id;
    public bool checkRead = false;

    //GameObject checkWall;

    //private void Start()
    //{
    //    player의 자식 중 하나인 CheckWall
    //    checkWall = GameObject.Find("CheckWall");
    //}

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.name == "CheckWall" || collision.gameObject.name == "Player")
        //{
        //    //this.transform.gameObject.GetComponent<Collider>().enabled = false;
        //    Destroy(gameObject.GetComponent<Collider>());
        //}
        if (collision.gameObject.tag != "Attack" && 
            collision.gameObject.tag != "Platform" && 
            collision.gameObject.tag != "Clock") 
        {
            Destroy(gameObject);
        }
    }
}