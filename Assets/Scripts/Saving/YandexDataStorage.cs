using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;

public class YandexDataStorage : MonoBehaviour, IDataStorage
{
    private readonly Dictionary<string, string> _temporaryStorage = new Dictionary<string, string>();

    private void Start()
    {
        YandexSDK.Instance.Authenticate();

        YandexSDK.Instance.UserDataReceivedEvent += LoadData;
        YandexSDK.Instance.WindowClosedEvent += UploadData;

        YandexSDK.Instance.RequestUserData();
    }

    public void GetData<T>(string key, T objectT)
    {
        if (_temporaryStorage.TryGetValue(key, out var value))
            JsonUtility.FromJsonOverwrite(value, objectT);
    }

    public void SaveData<T>(string key, T objectT)
    {
        var serializedObject = JsonUtility.ToJson(objectT);
        _temporaryStorage.Add(key, serializedObject);
    }

    private void LoadData(string data)
    {
        var parsedData = JSON.Parse(data);
        foreach (var dataKey in parsedData.Keys)
            _temporaryStorage[dataKey] = parsedData[dataKey];
    }

    private void UploadData()
    {
        foreach (var storageValue in _temporaryStorage.Values)
            YandexSDK.Instance.WriteUserData(storageValue);
    }

    private void OnDestroy()
    {
        YandexSDK.Instance.UserDataReceivedEvent -= LoadData;
        YandexSDK.Instance.WindowClosedEvent -= UploadData;
    }
}
