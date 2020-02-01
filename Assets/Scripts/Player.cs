using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData _currentPlayerData;

    private void Start()
    {
        PlayerDataHandler.Instance.DataProvider.GetPlayerData((playerData) =>
        {
            _currentPlayerData = playerData;
        });
    }

    private void OnDestroy()
    {
        PlayerDataHandler.Instance.DataProvider.SetPlayerData(_currentPlayerData,
            (isDone) => {

            });
    }


}
