public interface IDataStorage
{
    bool IsPrepared { get; }
    void GetData<T>(string key, T objectT);
    void SaveData<T>(string key, T objectT);
}
