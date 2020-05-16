using Newtonsoft.Json;
using System.Net.Http;

//using System.Net;
using System.Threading.Tasks;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    public GameResultData data = new GameResultData();

    public async Task UpdateData()
    {
        HttpClient client = new HttpClient();
        var content = await client.GetStringAsync("http://127.0.0.1:21337/game-result");

        var obj = JsonConvert.DeserializeObject<GameResultData>(content);

        data.GameID = obj.GameID;
        data.LocalPlayerWon = obj.LocalPlayerWon;
    }
}