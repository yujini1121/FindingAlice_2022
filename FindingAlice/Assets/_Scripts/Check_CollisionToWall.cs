using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check_CollisionToWall : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Platform")
            playerMovement.collisionToWall = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Platform")
            playerMovement.collisionToWall = false;
    }
}
