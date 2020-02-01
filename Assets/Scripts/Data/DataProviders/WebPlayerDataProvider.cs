using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class WebPlayerDataProvider : PlayerDataProviderBase
{
    [SerializeField] private string _url = "http://localhost:4000/player";

    public override void GetPlayerData(Action<PlayerData> playerDataCallback)
    {
        StartCoroutine(GetRequest(_url, playerDataCallback));
    } 

    IEnumerator GetRequest(string uri, Action<PlayerData> playerDataCallback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.LogError($"Cannot load data! {webRequest.error}");
            }
            else
            {
                Debug.Log($"Response from server: {webRequest.downloadHandler.text}");
            }

            var playerDataFromJson = JsonUtility.FromJson<PlayerData>(webRequest.downloadHandler.text);
            playerDataCallback(playerDataFromJson);
        }
    }

    public override void SetPlayerData(PlayerData playerData, Action<bool> onDoneCallback)
    {
        StartCoroutine(PostRequest(_url, playerData, onDoneCallback));
    }

    IEnumerator PostRequest(string uri, PlayerData data, Action<bool> onDoneCallback)
    {
        var playerDataJson = JsonUtility.ToJson(data);
        var request = new UnityWebRequest(uri, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(playerDataJson);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();

        if (request.error != null)
        {
            Debug.Log("Erro: " + request.error);
        }
        else
        {
            Debug.Log("All OK");
            Debug.Log("Status Code: " + request.responseCode);
        }
    }
}
