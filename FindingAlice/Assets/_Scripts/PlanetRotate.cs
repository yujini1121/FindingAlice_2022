using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotate : MonoBehaviour
{
    float x = 0;
    float z = 0;

    void Start()
    {
        
    }

    void Update()
    {
        x++;
        z++;

        transform.localRotation = Quaternion.Euler(new Vector3(x, 0, 0));
    }
}
