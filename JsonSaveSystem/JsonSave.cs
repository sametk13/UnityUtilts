using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonSave<T>
{
    public static void SaveData(string key, T obj)
    {
        var json = JsonConvert.SerializeObject(obj);
        PlayerPrefs.SetString(key, json);
        Debug.Log("Saved : " + json);
    }

    public static T LoadData(string key)
    {
        var json = PlayerPrefs.GetString(key);
        var data = JsonConvert.DeserializeObject<T>(json);
        Debug.Log("Loaded : " + json);

        return data;
    }
}

