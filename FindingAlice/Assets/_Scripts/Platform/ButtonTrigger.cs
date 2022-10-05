using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    Vector3 rot;

    private void Start()
    {
        //rot = this.gameObject.transform.Rotate(this, this, this);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            GetComponentInParent<Transparent>().require = true;
            //transform.rotation = Quaternion.Euler(x, 180, z);
        }
    }
}
