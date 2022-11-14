using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseCol_To_Wall : MonoBehaviour
{
    bool col_To_Wall;

    void Start()
    {
        col_To_Wall = GameObject.Find("Player").GetComponent<PlayerMovement>().collisionToWall;
    }

    void OnCollisionStay(Collision collision)
    {
        
    }
}