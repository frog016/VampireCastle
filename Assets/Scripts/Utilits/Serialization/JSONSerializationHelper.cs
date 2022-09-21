using System.IO;
using UnityEngine;

public static class JSONSerializationHelper
{
    private static string _scriptableObjectsDataDirectory = "DataSaves";

    public static void SaveObjectToJson(string name, object obj)
    {
        var directoryPath = Path.Combine(Application.persistentDataPath, _scriptableObjectsDataDirectory);
        var filePath = Path.Combine(directoryPath, $"{name}.json");

        if (!Directory.Exists(directoryPath))
            Directory.CreateDirectory(directoryPath);

        if (!File.Exists(filePath))
            File.Create(filePath).Dispose();

        var json = JsonUtility.ToJson(obj);
        File.WriteAllText(filePath, json);
    }

    public static bool TryLoadJson(string name, out string data)
    {
        var filePath = Path.Combine(
            Application.persistentDataPath,
            _scriptableObjectsDataDirectory,
            $"{name}.json"
        );

        if (!File.Exists(filePath))
        {
            data = null;
            return false;
        }

        data = File.ReadAllText(filePath);
        return true;
    }
}