using System;

public interface IPlayerDataProvider
{
    void GetPlayerData(Action<PlayerData> playerDataCallback);

    void SetPlayerData(PlayerData playerData, Action<bool> onDoneCallback);
}
