using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjData : MonoBehaviour
{
    public int id;
    public bool checkRead = false;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "CheckWall" || collision.gameObject.name == "Player")
            this.transform.gameObject.GetComponent<Collider>().enabled = false;
    }
}