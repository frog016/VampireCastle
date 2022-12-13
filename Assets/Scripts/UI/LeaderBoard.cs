using System;
using System.Collections;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] private GameObject _recordPrefab;
    [SerializeField] private Transform _leaderBoardTable;

    private void OnEnable()
    {
        YandexSDK.Instance.LeaderBoardReceivedEvent += FillLeaderBoard;
    }

    public void FillLeaderBoard(string jsonData)
    {
        ClearTable();

        var parsedJsonData = JSON.Parse(jsonData);
        for (var i = 0; i < parsedJsonData["entries"].Count; i++)
            CreateRecord(parsedJsonData["entries"][i]);
    }

    public void ClearTable()
    {
        if (_leaderBoardTable.childCount <= 0) 
            return;

        foreach (Transform child in _leaderBoardTable)
            Destroy(child.gameObject);
    }

    private void CreateRecord(JSONNode jsonData)
    {
        var record = Instantiate(_recordPrefab, _leaderBoardTable);
        var recordComponent = record.GetComponent<LeaderBoardRecordUI>();

        StartCoroutine(LoadTextureFromUrl(jsonData["player"]["getAvatarSrc"].Value, InitializeRecord));

        void InitializeRecord(Texture texture)
        {
            var recordData = new LeaderBoardRecordUI.LeaderBoardRecord
            (
                jsonData["player"]["publicName"].ToString(),
                int.Parse(jsonData["score"].ToString()),
                texture
            );

            recordComponent.InitializeRecord(recordData);
        }
    }

    private static IEnumerator LoadTextureFromUrl(string url, Action<Texture> response)
    {
        using var request = UnityWebRequestTexture.GetTexture(url);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.ProtocolError && request.result != UnityWebRequest.Result.ConnectionError)
        {
            response(DownloadHandlerTexture.GetContent(request));
        }
        else
        {
            Debug.LogErrorFormat("error request [{0}, {1}]", url, request.error);
            response(null);
        }
    }

    private void OnDisable()
    {
        YandexSDK.Instance.LeaderBoardReceivedEvent -= FillLeaderBoard;
    }
}
