using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiddleRotate : MonoBehaviour
{
    [SerializeField] float timer = 0;
    [SerializeField] int timeValue = 0;
    [SerializeField] bool _changeSceneFlag;

    public bool changeSceneFlag
    {
        get { return _changeSceneFlag; }
    }

    private void Update()
    {
        if (timer < 1)
        {
            timer += Time.deltaTime;
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, -30 + transform.rotation.eulerAngles.z));
            timer = 0;
            timeValue++;
        }

        if (timeValue >= 3)
        {
            _changeSceneFlag = true;
        }
    }
}
