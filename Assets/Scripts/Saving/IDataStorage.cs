public interface IDataStorage
{
    public void GetData<T>(string key, T objectT);
    public void SaveData<T>(string key, T objectT);
}
