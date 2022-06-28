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

    private void Start(){
        LoadGameData();
        SaveGameData();
    }

    public void LoadCheckPoint(){
        
    }

    public void LoadGameData(){
        string filePath = Application.persistentDataPath + GameDataFileName;

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
        string filePath = Application.persistentDataPath + GameDataFileName;

        File.WriteAllText(filePath, ToJsonData);

        Debug.Log("Save Succes");
        Debug.Log("Chaper 1" + gameData.isClear1);
        Debug.Log("Chaper 2" + gameData.isClear2);
        Debug.Log("Chaper 3" + gameData.isClear3);
        Debug.Log("savePoint"+ gameData.playerPosition);
    }

    private void OnApplicationQuit() {
        SaveGameData();    
    }
}