using System;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public static SaveSystem instance;

    private string filePath;

    private void Awake()
    {
        instance = this;
        filePath = $"{Application.persistentDataPath}/save.save";
    }

    [ContextMenu("Save")]
    public void Save()
    {
        SaveData saveData = new()
        {
            characterDTO = FindAnyObjectByType<PlayerHealth>().Serialized(),
        };

        try
        {
            string json = JsonConvert.SerializeObject(saveData, Formatting.Indented);

            using FileStream stream = new(filePath, FileMode.Create);
            using StreamWriter writer = new(stream);
            writer.Write(json);
        }
        catch (Exception ex)
        {
            Debug.Log($"JSON serialization failed\n{ex}");
        }
    }

    [ContextMenu("Load")]
    public void Load()
    {
        try
        {
            using StreamReader reader = new(filePath);
            string json = reader.ReadToEnd();

            SaveData saveData = JsonConvert.DeserializeObject<SaveData>(json);

            FindAnyObjectByType<PlayerHealth>().Deserialize(saveData.characterDTO);
        }
        catch(Exception ex)
        {
            Debug.Log($"JSON deserialization failed\n{ex}");
        }
    }
}