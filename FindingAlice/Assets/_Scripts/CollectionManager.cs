using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectionManager : MonoBehaviour
{
    public bool[] collection;

    string sceneName;

    private void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "Chapter_T":
                collection = new bool[DataController.Instance.gameData.chT_Collection.Length];
                for (int i = 0; i < collection.Length; i++)
                    collection[i] = DataController.Instance.gameData.chT_Collection[i];
                break;
            case "Chapter_1":
                collection = new bool[DataController.Instance.gameData.ch1_Collection.Length];
                for (int i = 0; i < collection.Length; i++)
                    collection[i] = DataController.Instance.gameData.ch1_Collection[i];
                break;
            case "Chapter_2":
                collection = new bool[DataController.Instance.gameData.ch2_Collection.Length];
                for (int i = 0; i < collection.Length; i++)
                    collection[i] = DataController.Instance.gameData.ch2_Collection[i];
                break;
            case "Chapter_3":
                collection = new bool[DataController.Instance.gameData.ch3_Collection.Length];
                for (int i = 0; i < collection.Length; i++)
                    collection[i] = DataController.Instance.gameData.ch3_Collection[i];
                break;
        }
    }

    void Start()
    {
    }

    public void GetItem(int index)
    {
        collection[index] = true;
    }

    public void SaveCollectionData()
    {
        switch (sceneName)
        {
            case "Chapter_T":
                for (int i = 0; i < collection.Length; i++)
                    DataController.Instance.gameData.chT_Collection[i] = collection[i];
                break;
            case "Chapter_1":
                for (int i = 0; i < collection.Length; i++)
                    DataController.Instance.gameData.ch1_Collection[i] = collection[i];
                break;
            case "Chapter_2":
                for (int i = 0; i < collection.Length; i++)
                    DataController.Instance.gameData.ch2_Collection[i] = collection[i];
                break;
            case "Chapter_3":
                for (int i = 0; i < collection.Length; i++)
                    DataController.Instance.gameData.ch3_Collection[i] = collection[i];
                break;
        }
    }
}
