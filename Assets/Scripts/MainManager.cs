using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// script enables you to access the MainManager object from any other script
public class MainManager : MonoBehaviour
{
    // will be shared by all the instances of that class
    public static MainManager Instance;

    public Color TeamColor; // new variable declared

    private void Awake()
    {

        if (Instance != null)
        { 
            Destroy(gameObject);
            return;
        }

        // get a link to the that specific instance of it
        Instance = this;

        // not to be destroyed when the scene changes
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }


    // required for JsonUtility
    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }

    public void SaveColor()
    { 
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        // transform instance to JSON
        string json = JsonUtility.ToJson(data);

        // write string to a file
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    // reversal of the SaveColor method
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        { 
            // read its content
            string json = File.ReadAllText(path);

            // transform it back into SaveData instance 
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            // set color
            TeamColor = data.TeamColor;
        }
    }
}