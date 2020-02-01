using System;
using UnityEngine;

public abstract class PlayerDataProviderBase : MonoBehaviour, IPlayerDataProvider
{
    public abstract void GetPlayerData(Action<PlayerData> playerDataCallback);

    public abstract void SetPlayerData(PlayerData playerData, Action<bool> onDoneCallback);
}
