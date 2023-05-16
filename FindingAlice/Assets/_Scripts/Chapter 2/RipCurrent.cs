using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipCurrent : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    private float defultRipCurrentSpeed = 10.0f;
    private float curRipCurrentSpeed;
    void Start()
    {
        curRipCurrentSpeed = defultRipCurrentSpeed;
    }
    void OnTriggerStay(Collider other)
    {
        playerMovement._speedOffset = new Vector3(10.0f,0,0);
        playerMovement.ChangeJumpType(JumpType.Lock);
    }
    void OnTriggerExit(Collider other)
    {
        StartCoroutine(ExitRipCurrent());
        
    }
    IEnumerator ExitRipCurrent()
    {
        while (playerMovement._speedOffset!= Vector3.zero)
        {
            playerMovement._speedOffset = Vector3.Lerp(playerMovement._speedOffset, Vector3.zero, 0.01f);
            if(playerMovement._speedOffset.x<=1.0f)
            {
                playerMovement._speedOffset = Vector3.zero;
                playerMovement.ChangeJumpType(JumpType.Infinity);
                yield break;
            }
            yield return null;
        }
        
    }
}
