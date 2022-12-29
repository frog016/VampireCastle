using UnityEngine;

public abstract class SavableScriptableObject : ScriptableObject, ISerializationCallbackReceiver
{
    public void LoadData(IDataStorage dataStorage)
    {
        dataStorage.GetData(GetType().Name, this);
    }

    public void SaveData(IDataStorage dataStorage)
    {
        dataStorage.SaveData(GetType().Name, this);
    }

    public void OnBeforeSerialize() { }

    public abstract void OnAfterDeserialize();
}
