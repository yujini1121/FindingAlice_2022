using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

class SavePoint{
    public float positionX;
    public float positionY;
}

public class SLManager : MonoBehaviour
{
    List<SavePoint> data = new List<SavePoint>();
    public void _save(){
        var sdata = JsonConvert.SerializeObject(data);
        File.WriteAllText(Application.dataPath + "/SaveFile.json", sdata);
    }
    public void _load(){
        var sdata = File.ReadAllBytes(Application.dataPath + "/SaveFile.json");
    }
}
