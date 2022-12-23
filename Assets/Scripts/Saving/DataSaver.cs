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

    private void OnEnable()
    {
        foreach (var savableScriptableObject in _savableScriptableObjects)
            savableScriptableObject.LoadData(_dataStorage);
    }

    private void OnApplicationQuit()
    {
        foreach (var savableScriptableObject in _savableScriptableObjects)
            savableScriptableObject.SaveData(_dataStorage);
    }
}
