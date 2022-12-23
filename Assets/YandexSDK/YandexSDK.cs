using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class YandexSDK : MonoBehaviour
{
    public static YandexSDK Instance { get; private set; }

    public event Action WindowClosedEvent;
    public event Action InterstitialShownEvent;
    public event Action LeaderBoardScoreWrittenEvent;

    public event Action<string> InterstitialFailedEvent;
    public event Action<string> LeaderBoardReceivedEvent;
    public event Action<string> UserDataReceivedEvent;

    public event Action<RewardAdEventArgs> RewardedAdEvent;
    public event Action<PurchaseEventArgs> PurchaseEvent;
    
    private readonly Queue<int> _rewardedAdPlacementsInt = new Queue<int>();
    private readonly Queue<string> _rewardedAdsPlacements = new Queue<string>();

    [DllImport("__Internal")]
    private static extern void GetUserData();
    [DllImport("__Internal")]
    private static extern void SetUserData(string data);
    [DllImport("__Internal")]
    private static extern void ShowFullscreenAd();
    [DllImport("__Internal")]
    private static extern int ShowRewardedAd(string placement);
    [DllImport("__Internal")]
    private static extern void AuthenticateUser();
    [DllImport("__Internal")]
    private static extern void InitPurchases();
    [DllImport("__Internal")]
    private static extern void Purchase(string id);
    [DllImport("__Internal")]
    private static extern void GetLeaderBoard();
    [DllImport("__Internal")]
    private static extern void WriteLeaderBoardScore(int score);

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    #region API methods

    public void Authenticate()
    {
        AuthenticateUser();
    }

    public void RequestUserData()
    {
        GetUserData();
    }

    public void WriteUserData(string data)
    {
        SetUserData(data);
    }

    public void RequestLeaderBoard()
    {
        GetLeaderBoard();
    }

    public void WriteScore(int score)
    {
        WriteLeaderBoardScore(score);
    }

    public void ShowAd()
    {
        ShowFullscreenAd();
    }

    public void ShowRewarded(string placement)
    {
        _rewardedAdPlacementsInt.Enqueue(ShowRewardedAd(placement));
        _rewardedAdsPlacements.Enqueue(placement);
    }

    public void InitializePurchases()
    {
        InitPurchases();
    }

    public void ProcessPurchase(string id)
    {
        Purchase(id);
    }

    #endregion

    #region Index.html callbacks

    public void OnGettingPlayerDataCallback(string data)
    {
        UserDataReceivedEvent?.Invoke(data);
    }

    public void OnInterstitialShownCallback()
    {
        InterstitialShownEvent?.Invoke();
    }

    public void OnInterstitialFailedCallback(string error)
    {
        InterstitialFailedEvent?.Invoke(error);
    }

    public void OnRewardedOpenCallback(int placement)
    {
        RewardedAdEvent?.Invoke(
            new RewardAdEventArgs(placement, "", RewardAdEventArgs.RewardAdResult.Opened)
            );
    }

    public void OnRewardedCallback(int placement)
    {
        if (placement != _rewardedAdPlacementsInt.Dequeue())
            return;

        var adPlacement = _rewardedAdsPlacements.Dequeue();
        RewardedAdEvent?.Invoke(
            new RewardAdEventArgs(placement, adPlacement, RewardAdEventArgs.RewardAdResult.Rewarded)
        );
    }

    public void OnRewardedCloseCallback(int placement)
    {
        RewardedAdEvent?.Invoke(
            new RewardAdEventArgs(placement, "", RewardAdEventArgs.RewardAdResult.Closed)
        );
    }

    public void OnRewardedErrorCallback(string data)
    {
        var parsedData = JsonUtility.FromJson<RewardAdEventArgs>(data);
        RewardedAdEvent?.Invoke(
            new RewardAdEventArgs(parsedData.Id, parsedData.ResultText, RewardAdEventArgs.RewardAdResult.Error)
        );

        _rewardedAdsPlacements.Clear();
        _rewardedAdPlacementsInt.Clear();
    }

    public void OnLeaderBoardReceivedCallback(string data)
    {
        LeaderBoardReceivedEvent?.Invoke(data);
    }

    public void OnLeaderBoardScoreWrittenCallback()
    {
        LeaderBoardScoreWrittenEvent?.Invoke();
    }

    public void OnPurchaseSuccessCallback(string id)
    {
        PurchaseEvent?.Invoke(
            new PurchaseEventArgs(int.Parse(id), "", PurchaseEventArgs.PurchaseResult.Success)
            );
    }

    public void OnPurchaseFailedCallback(string data)
    {
        var parsedData = JsonUtility.FromJson<PurchaseEventArgs>(data);
        PurchaseEvent?.Invoke(
            new PurchaseEventArgs(parsedData.Id, parsedData.ResultText, PurchaseEventArgs.PurchaseResult.Success)
        );
    }

    public void OnCloseCallback()
    {
        WindowClosedEvent?.Invoke();
    }

    #endregion
}

[Serializable]
public struct PurchaseEventArgs
{
    public readonly int Id;
    public readonly string ResultText;
    public readonly PurchaseResult Result;

    public PurchaseEventArgs(int id, string resultText, PurchaseResult result)
    {
        Id = id;
        ResultText = resultText;
        Result = result;
    }

    public enum PurchaseResult
    {
        Success,
        Failed
    }
}

[Serializable]
public struct RewardAdEventArgs
{
    public readonly int Id;
    public readonly string ResultText;
    public readonly RewardAdResult AdResult;

    public RewardAdEventArgs(int id, string resultText, RewardAdResult adResult)
    {
        Id = id;
        ResultText = resultText;
        AdResult = adResult;
    }

    public enum RewardAdResult
    {
        Opened,
        Rewarded,
        Closed,
        Error
    }
}

[Serializable]
public struct UserData
{
    public string Id;
    public string Name;
    public string ImageUrl;

    public UserData(string id, string name, string url)
    {
        Id = id;
        Name = name;
        ImageUrl = url;
    }
}
