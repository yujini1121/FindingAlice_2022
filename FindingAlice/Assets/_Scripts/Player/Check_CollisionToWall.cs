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

    private void OnTriggerEnter(Collider other)
    {
        //playerMovement.isGround = false;
        //playerMovement.AnimControl("isGrounded", false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Platform")
        {
            playerMovement.collisionToWall = true;
            //playerMovement.isGround = false;
            //playerMovement.AnimControl("isGrounded", false);
            if(ClockManager.C.CS == ClockState.follow)
                ClockManager.C.clockReset();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Platform")
        {
            //playerMovement.isGround = true;
            playerMovement.collisionToWall = false;
            //playerMovement.isGround = true;
        }
    }
}
