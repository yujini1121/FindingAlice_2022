using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    float x, y, z;

    private void Start()
    {
        x = transform.localScale.x;
        y = transform.localScale.y;
        z = transform.localScale.z;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            GetComponentInParent<Transparent>().require = true;

            this.transform.localScale = new Vector3(-x, y, z);
            Invoke("ReturnScale", GetComponentInChildren<Transparent>().holdingTime);
        }
    }

    private void ReturnScale()
    {
        this.transform.localScale = new Vector3(x, y, z);
    }
}