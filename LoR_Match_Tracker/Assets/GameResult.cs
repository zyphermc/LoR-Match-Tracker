﻿using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    public GameResultData data = new GameResultData();

    public async Task UpdateData()
    {
        try
        {
            HttpClient client = new HttpClient();
            var content = await client.GetStringAsync("http://127.0.0.1:21337/game-result");

            var obj = JsonConvert.DeserializeObject<GameResultData>(content);

            data.GameID = obj.GameID;
            data.LocalPlayerWon = obj.LocalPlayerWon;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}