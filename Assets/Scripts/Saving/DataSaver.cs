using System;
using System.Collections;
using UnityEngine;

public class DataSaver : MonoBehaviour
{
    [SerializeField] private SavableScriptableObject[] _savableScriptableObjects;
    
    private IDataStorage _dataStorage;

    private static DataSaver _instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);

        _dataStorage = GetComponent<IDataStorage>();
    }


    private void OnEnable() => StartCoroutine(WaitUnitPreparedCoroutine(ReceiveData));

    public void ReceiveData()
    {
        foreach (var savableScriptableObject in _savableScriptableObjects)
            savableScriptableObject.LoadData(_dataStorage);
    }

    public void SaveData()
    {
        foreach (var savableScriptableObject in _savableScriptableObjects)
            savableScriptableObject.SaveData(_dataStorage);
    }

    private void OnApplicationQuit() => SaveData();

    private IEnumerator WaitUnitPreparedCoroutine(Action action)
    {
        yield return new WaitUntil(() => _dataStorage.IsPrepared);
        action();
    }
}
