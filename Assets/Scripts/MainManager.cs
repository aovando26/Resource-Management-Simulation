using System.Collections;
using System.Collections.Generic;
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
    }


    // required for JsonUtility
    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;
    }
}