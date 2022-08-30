using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataController : MonoBehaviour
{
    static GameObject _container;
    static GameObject Container{
        get{
            return _container;
        }
    }
    static DataController _intance;
    public static DataController Instance{
        get{
            if(!_intance){
                _container = new GameObject();
                _container.name = "DataController";
                _intance = _container.AddComponent(typeof(DataController)) as DataController;
                DontDestroyOnLoad(_container);
            }
            return _intance;
        }
    }
    public string GameDataFileName = "FindingAlliceData.json";

    public GameData _gameData;
    public GameData gameData{
        get{
            if(_gameData == null){
                LoadGameData();
                SaveGameData();
            }
            return _gameData;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start(){
        LoadGameData();
        SaveGameData();
    }

    public void LoadGameData(){
        string filePath = Application.dataPath + "/SaveFile/" + GameDataFileName;

        if(File.Exists(filePath)){
            Debug.Log("Load Succes");
            string FromJsonData = File.ReadAllText(filePath);
            _gameData = JsonUtility.FromJson<GameData>(FromJsonData);
        }
        else{
            Debug.Log("Create New File");
            _gameData = new GameData();
        }
    }

    public void SaveGameData(){
        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.dataPath + "/SaveFile/" + GameDataFileName;

        File.WriteAllText(filePath, ToJsonData);

        Debug.Log("Save Succes");
        Debug.Log("savePoint"+ gameData.playerPosition);
    }

    private void OnApplicationQuit() {
        SaveGameData();    
    }
}