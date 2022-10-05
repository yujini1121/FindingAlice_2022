using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace AT.HUDSystem
{
    public enum HUD_OBJECT_TYPE
    {
        Damage_Normal,
        Damage_Critical,
    }

    [System.Serializable]
    public class DictionaryOfHUDTypeAndTextMesh : /*AT.SerializableDictionary.*/SerializableDictionary<HUD_OBJECT_TYPE, TextMeshPro> { }

    [System.Serializable]
    public class DictionaryOfPoolBase : /*AT.SerializableDictionary.*/SerializableDictionary<HUD_OBJECT_TYPE, List<TextMeshPro>> { }

    public class HUDSystem : MonoBehaviour
    {
        /// <summary> HUD System Prefab List </summary>
        public DictionaryOfHUDTypeAndTextMesh prefabList = new DictionaryOfHUDTypeAndTextMesh();

        /// <summary> HUD System Pool Container </summary>
        public DictionaryOfPoolBase pools = new DictionaryOfPoolBase();

        public void Initialize()
        {
            pools.Clear();
            foreach (var obj in prefabList)
            {
                List<TextMeshPro> poolList = new List<TextMeshPro>();
                pools.Add(obj.Key, poolList);
            }
        }

        public TextMeshPro CreateItem(HUD_OBJECT_TYPE type)
        {
            if (prefabList.ContainsKey(type))
            {
                TextMeshPro newTextMesh = Instantiate(prefabList[type]);
                newTextMesh.transform.position = Vector3.zero;
                return newTextMesh;
            }

            Debug.LogErrorFormat("Can not Find Target HUD Object. Type : {0}", type.ToString());
            return null;
        }

        public TextMeshPro GetItem(HUD_OBJECT_TYPE type)
        {
            for (int i = 0; i < pools[type].Count; i++)
            {
                if (!pools[type][i].gameObject.activeSelf)
                    return pools[type][i];
            }
            return CreateItem(type);
        }
    }
}