using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GameData
{
    public Vector3 position;
    public SerializableDictionary<string, bool> itemCollected;
}

public class GameDataManager: MonoBehaviour
{
    GameData gameData;
    string saveFilePath;
    private List<IDataGrabber> dataPersistenceObjects;
    private void Awake()
    {
        gameData = new GameData
        {
            position = new Vector3(-2.9f, 5.2f, 0.0f),
            itemCollected = new SerializableDictionary<string, bool>()
        };

        saveFilePath =  Application.persistentDataPath + "/GameData.Json";
        dataPersistenceObjects = FindAllDataPersistenceObjects();
    }

    private void Start()
    {
        LoadGame();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            SaveGame();
            Debug.Log("Game Saved");
        }
    }

    public void SaveGame()
    {
        string saveGameData = JsonUtility.ToJson(gameData);
        File.WriteAllText(saveFilePath, saveGameData);
        foreach(IDataGrabber dataPersistenceObj in dataPersistenceObjects)
        {
            dataPersistenceObj.SaveData(gameData);
        }
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string loadGameData =  File.ReadAllText(saveFilePath);
            gameData =  JsonUtility.FromJson<GameData>(loadGameData);
            foreach(IDataGrabber dataPersistenceObj in dataPersistenceObjects)
            {
                dataPersistenceObj.LoadData(gameData);
            }
        }
        else
        {
            Debug.LogError("Save file does not exist, creating a new one");
            SaveGame();
        }
    }

    public void DeleteSaveData()
    {
        if (File.Exists(saveFilePath))
        {
            File.Delete(saveFilePath);
        }
    }

    private List<IDataGrabber> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataGrabber> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>(true).OfType<IDataGrabber>();

        return new List<IDataGrabber>(dataPersistenceObjects);
    }
}
