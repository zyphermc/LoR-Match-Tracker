using System.Collections;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 4014
//#pragma warning restore xxxx

public class runeterraCount : MonoBehaviour
{
    [HideInInspector] public TextMeshProUGUI text_pvp_win;
    [HideInInspector] public TextMeshProUGUI text_pvp_loss;
    [HideInInspector] public TextMeshProUGUI text_ai_win;
    [HideInInspector] public TextMeshProUGUI text_ai_loss;
    [HideInInspector] public TextMeshProUGUI text_friend_win;
    [HideInInspector] public TextMeshProUGUI text_friend_loss;

    [HideInInspector] public Toggle toggle_pvp;
    [HideInInspector] public Toggle toggle_ai;
    [HideInInspector] public Toggle toggle_friend;

    public GameObject FrontPage;
    public GameObject StatisticsPage;

    private int pvp_winCount;
    private int pvp_lossCount;
    private int ai_winCount;
    private int ai_lossCount;
    private int friend_winCount;
    private int friend_lossCount;

    //Server-side values to client side
    [SerializeField] private int currentGameID;
    [SerializeField] private bool currentGameResult;
    [SerializeField] private bool syncData;
    [SerializeField] private int gameType;

    public GameResult gameResult;
    
    private IEnumerator UpdateDataEnum()
    {
        while (true)
        {
            UpdateData();

            Debug.Log("GameID: " + gameResult.data.GameID);
            Debug.Log("Result: " + gameResult.data.LocalPlayerWon);

            if (currentGameID != gameResult.data.GameID)
            {
                currentGameID = gameResult.data.GameID;
                currentGameResult = gameResult.data.LocalPlayerWon;

                if (syncData == true) //if local data is synced to server
                {
                    if (currentGameResult == true)
                    {
                        //increment_win
                        switch (gameType)
                        {
                            case 0:
                                increment_pvp_win();
                                break;
                            case 1:
                                increment_ai_win();
                                break;
                            case 2:
                                increment_friend_win();
                                break;
                        }
                    }
                    else
                    {
                        //increment_loss
                        switch (gameType)
                        {
                            case 0:
                                increment_pvp_loss();
                                break;
                            case 1:
                                increment_ai_loss();
                                break;
                            case 2:
                                increment_friend_loss();
                                break;
                        }
                    }
                }
                else
                {
                    syncData = true;
                }
            }

            yield return new WaitForSeconds(1f);
        }
    }

    private async Task UpdateData()
    {
        await gameResult.UpdateData();
    }

    private void Start()
    {
        StartCoroutine("UpdateDataEnum");
        toggle_pvp.isOn = true;
        gameType = 0;
        syncData = false;
    }

    // Update is called once per frame
    private void Update()
    {
        text_pvp_win.text = "Wins: " + pvp_winCount.ToString();
        text_pvp_loss.text = "Loss: " + pvp_lossCount + "/10";
        text_ai_win.text = "Wins: " + ai_winCount + "/10";
        text_ai_loss.text = "Loss: " + ai_lossCount + "/10"; ;
        text_friend_win.text = "Wins: " + friend_winCount + "/5"; ;
        text_friend_loss.text = "Loss: " + friend_lossCount + "/5"; ;

        //Change color if task is finished
        if (pvp_lossCount >= 10)
        {
            text_pvp_loss.color = Color.green;
        }
        else
        {
            text_pvp_loss.color = Color.black;
        }

        if (ai_winCount >= 10)
        {
            text_ai_win.color = Color.green;
        }
        else
        {
            text_ai_win.color = Color.black;
        }

        if (ai_lossCount >= 10)
        {
            text_ai_loss.color = Color.green;
        }
        else
        {
            text_ai_loss.color = Color.black;
        }

        if (friend_winCount >= 5)
        {
            text_friend_win.color = Color.green;
        }
        else
        {
            text_friend_win.color = Color.black;
        }

        if (friend_lossCount >= 5)
        {
            text_friend_loss.color = Color.green;
        }
        else
        {
            text_friend_loss.color = Color.black;
        }
    }

    //Increment functions
    public void increment_pvp_win()
    {
        pvp_winCount++;
    }

    public void decrement_pvp_win()
    {
        pvp_winCount--;
    }

    public void increment_pvp_loss()
    {
        pvp_lossCount++;
    }

    public void decrement_pvp_loss()
    {
        pvp_lossCount--;
    }

    /////
    public void increment_ai_win()
    {
        ai_winCount++;
    }

    public void decrement_ai_win()
    {
        ai_winCount--;
    }

    public void increment_ai_loss()
    {
        ai_lossCount++;
    }

    public void decrement_ai_loss()
    {
        ai_lossCount--;
    }

    /////
    public void increment_friend_win()
    {
        friend_winCount++;
    }

    public void decrement_friend_win()
    {
        friend_winCount--;
    }

    public void increment_friend_loss()
    {
        friend_lossCount++;
    }

    public void decrement_friend_loss()
    {
        friend_lossCount--;
    }

    /////
    public void resetCounter()
    {
        pvp_winCount = 0;
        pvp_lossCount = 0;
        ai_winCount = 0;
        ai_lossCount = 0;
        friend_winCount = 0;
        friend_lossCount = 0;
    }

    public void UpdateToggle()
    {
        if (toggle_pvp.isOn)
        {
            gameType = 0;
        }
        else

        if (toggle_ai.isOn)
        {
            gameType = 1;
        }
        else

        if (toggle_friend.isOn)
        {
            gameType = 2;
        }
    }

    public void SwitchPage()
    {
        if (FrontPage.activeSelf)
        {
            StatisticsPage.SetActive(true);
            FrontPage.SetActive(false);
        }
        else if (StatisticsPage.activeSelf)
        {
            FrontPage.SetActive(true);
            StatisticsPage.SetActive(false);
        }
    }
}