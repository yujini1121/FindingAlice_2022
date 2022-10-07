using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    float x, y, z;

    float transHoldingTime;

    private void Start()
    {
        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;

        transHoldingTime = transform.parent.GetComponentInParent<Transparent>().holdingTime;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            GetComponentInParent<Transparent>().require = true;

            transform.localScale = new Vector3(-x, y, z);
            CancelInvoke();
            Invoke("ReturnScale", transHoldingTime);
        }
    }

    public void ReturnScale()
    {
        transform.localScale = new Vector3(x, y, z);
    }
}