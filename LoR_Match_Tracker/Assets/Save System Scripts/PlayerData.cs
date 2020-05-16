[System.Serializable]

public class PlayerData
{
    #region Data Variables

    public int pvp_wins;
    public int pvp_losses;
    public int ai_wins;
    public int ai_losses;
    public int friend_wins;
    public int friend_losses;

    #endregion Data Variables

    public PlayerData(ProfileStatistics profileStatistics)
    {
        pvp_wins = profileStatistics.pvp_wins;
        pvp_losses = profileStatistics.pvp_losses;
        ai_wins = profileStatistics.ai_wins;
        ai_losses = profileStatistics.ai_losses;
        friend_wins = profileStatistics.friend_wins;
        friend_losses = profileStatistics.friend_losses;
    }
}