using UnityEngine;

public class JsonDataStorage : MonoBehaviour, IDataStorage
{
    private void OnEnable()
    {
    }

    public void GetData<T>(string key, T objectT)
    {
        if (JSONSerializationHelper.TryLoadJson(key, out var data))
            JsonUtility.FromJsonOverwrite(data, objectT);
    }

    public void SaveData<T>(string key, T objectT)
    {
        JSONSerializationHelper.SaveObjectToJson(key, objectT);
    }
}