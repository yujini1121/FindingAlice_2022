using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    [SerializeField] GameObject[] collection;

    int collectionCount;
    

    void Start()
    {
        //collectionCount = 
    }

    void Update()
    {
        
    }

    public void GetItem(int array)
    {
        collection[array].SetActive(false);

    }
}
