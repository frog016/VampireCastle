using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class YandexSDK : MonoBehaviour
{
    public UserData UserData { get; private set; }
    public UserGameData UserGameData { get; private set; }

    public event Action AuthSuccessEvent;
    public event Action DataReceivedEvent;
    public event Action RewardReceivedEvent;
    public event Action<string> LeaderBoardReceivedEvent;

    public static YandexSDK Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<YandexSDK>();

            return _instance;
        }
    }

    private static YandexSDK _instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    public void Authenticate()
    {
        Auth();
    }

    public void GettingData()
    {
        GetData();
    }

    public void SettingData(string data)
    {
        SetData(data);
    }

    public void GetLeaderEntries()
    {
        GetLeaderBoardEntries();
    }

    public void SetLeaderScore(int score)
    {
        SetLeaderBoard(score);
    }

    public void BoardEntriesReady(string data)
    {
        LeaderBoardReceivedEvent?.Invoke(data);
    }

    public void ShowCommonAd()
    {
        ShowCommonADV();
    }

    public void ShowRewardAdv()
    {
        ShowRewardADV();
    }


    public void AuthenticateSuccess(string data)
    {
        UserData.Name = data;
        AuthSuccessEvent?.Invoke();
    }

    public void DataGetting(string data)
    {
        UserGameData = JsonUtility.FromJson<UserGameData>(data);
        DataReceivedEvent?.Invoke();
    }

    public void RewardGetting()
    {
        RewardReceivedEvent?.Invoke();
    }

    [DllImport("__Internal")]
    private static extern void Auth();    // Авторизация - внешняя функция для связи с плагином
    [DllImport("__Internal")]
    private static extern void ShowCommonADV();    // Показ обычной рекламы - внешняя функция для связи с плагином
    [DllImport("__Internal")]
    private static extern void GetData();    // Получение данных - внешняя функция для связи с плагином
    [DllImport("__Internal")]
    private static extern void SetData(string data);    // Отправка данных - внешняя функция для связи с плагином
    [DllImport("__Internal")]
    private static extern void ShowRewardADV();    // Показ рекламы с наградой - внешняя функция для связи с плагином
    [DllImport("__Internal")]
    private static extern void GetLeaderBoardEntries();
    [DllImport("__Internal")]
    private static extern void SetLeaderBoard(int score);
}

[Serializable]
public class UserData
{
    public string Name;
    public string ImageURL;
}

[Serializable]
public class UserGameData
{
    public int Coin;

    public UserGameData(int coin)
    {
        Coin = coin;
    }
}