using UnityEngine;

public class SerializableScriptableObject<T> : SingletonScriptableObject<T>, ISerializable where T: SingletonScriptableObject<T>
{
    private void OnEnable()
    {
        LoadData();
    }

    public void SaveData()
    {
        JSONSerializationHelper.SaveObjectToJson(name, this);
    }

    public void LoadData()
    {
        if (JSONSerializationHelper.TryLoadJson(name, out var json))
            JsonUtility.FromJsonOverwrite(json, this);
    }

    private void OnDisable()
    {
        SaveData();
    }
}