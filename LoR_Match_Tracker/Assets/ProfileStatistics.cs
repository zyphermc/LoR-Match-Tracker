using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProfileStatistics : MonoBehaviour
{

    private int total_wins;
    private int total_losses;

    public int pvp_wins;
    public int pvp_losses;
    public int ai_wins;
    public int ai_losses;
    public int friend_wins;
    public int friend_losses;

    public TextMeshProUGUI text_statistics;

    // Update is called once per frame
    void Update()
    {
        total_wins = pvp_wins + ai_wins + friend_wins;
        total_losses = pvp_losses + ai_losses + friend_losses;

        text_statistics.text = 
              "Total Matches Won: " + total_wins + "\n"
            + "Total Matches Lost: " + total_losses + "\n\n"
            + "PVP Matches Won: " + pvp_wins + "\n"
            + "PVP Matches Lost: " + pvp_losses + "\n\n"
            + "AI Matches Won: " + ai_wins + "\n"
            + "AI Matches Lost: " + ai_losses + "\n\n"
            + "Friend Matches Won: " + friend_wins + "\n"
            + "Friend Matches Lost: " + friend_losses + "\n";
    }
}
