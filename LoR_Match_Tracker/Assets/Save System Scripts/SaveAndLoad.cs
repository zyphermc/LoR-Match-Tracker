using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    //Objects to reference to replace loaded data
    public ProfileStatistics profileStatistics;

    public SaveSystem SaveSystem; //Save System Object

    private void Start()
    {
        Load(); //Loads save at startup
    }

    //Save and Load Methods - Saves the current data to file, and Loads data from file then updating the current values
    public void Save()
    {
        SaveSystem.SaveData();
        Debug.Log("Data saved successfully.");
    }

    public void Load()
    {
        PlayerData data = SaveSystem.LoadData();
        Debug.Log("Data loaded successfully.");

        profileStatistics.pvp_wins = data.pvp_wins;
        profileStatistics.pvp_losses = data.pvp_losses;

        profileStatistics.ai_wins = data.ai_wins;
        profileStatistics.ai_losses = data.ai_losses;

        profileStatistics.friend_wins = data.friend_wins;
        profileStatistics.friend_losses = data.friend_losses;
    }
}