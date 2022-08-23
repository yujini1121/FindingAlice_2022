using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotate : MonoBehaviour
{
    float value = 0;
    [SerializeField] float speed = 100;

    void Start()
    {
        
    }

    void Update()
    {
        value += speed * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(new Vector3(0, value, 0));
    }
}
