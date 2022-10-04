using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyRight : MonoBehaviour
{
    GameObject copyRightPop;
    bool check;

    public void PopCopyRight()
    {
        gameObject.SetActive(!check);
        check = !check;
    }
}
