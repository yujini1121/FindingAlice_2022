using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(destroy());
    }

    IEnumerator destroy()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.down * 100, ForceMode.Impulse);
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
