using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour
{
    Vector3 position;

    void Start()
    {
        position = transform.localPosition;
    }

    void FixedUpdate()
    {
        position.x += 0.02f;
        transform.localPosition = position;
    }
}
