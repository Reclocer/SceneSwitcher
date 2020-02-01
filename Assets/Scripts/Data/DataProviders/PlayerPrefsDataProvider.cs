using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDataProvider : PlayerDataProviderBase
{
    public override void GetPlayerData(Action<PlayerData> playerDataCallback)
    {
        var name = PlayerPrefs.GetString("name", "UNDEFINED");
        int hp = PlayerPrefs.GetInt("hp", 0);
        int bullets = PlayerPrefs.GetInt("bullets", 0);

        var playerData = new PlayerData()
        {
            nickname = name,
            hp = hp,
            bullets = bullets
        };        

        playerDataCallback(playerData);

    }

    public override void SetPlayerData(PlayerData playerData, Action<bool> onDoneCallback)
    {
        PlayerPrefs.SetString("name", playerData.nickname);
        PlayerPrefs.SetInt("hp", playerData.hp);
        PlayerPrefs.SetInt("bullets", playerData.bullets);


        onDoneCallback(true);
    }
}
