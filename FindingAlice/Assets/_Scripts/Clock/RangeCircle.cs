using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCircle : MonoBehaviour
{
    float angle;

    void Update()
    {
        angle += Time.deltaTime * 500f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
