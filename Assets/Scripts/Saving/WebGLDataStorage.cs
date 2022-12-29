using System.Runtime.InteropServices;
using UnityEngine;

public class WebGLDataStorage : MonoBehaviour, IDataStorage
{
    [DllImport("__Internal")]
    private static extern void SyncFiles();

    public bool IsPrepared { get; private set; }

    private void OnEnable() => IsPrepared = true;

    public void GetData<T>(string key, T objectT)
    {
        if (JSONSerializationHelper.TryLoadJson(key, out var data))
            JsonUtility.FromJsonOverwrite(data, objectT);
    }

    public void SaveData<T>(string key, T objectT)
    {
        JSONSerializationHelper.SaveObjectToJson(key, objectT);
        SyncFiles();
    }

    private void OnDisable() => IsPrepared = false;
}
